using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public static Action onDead;
    
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private float _timeReload;
    
    
    private Rigidbody2D _rigidbody;
    private bool canShoot;

    private void OnEnable()
    {
        Controls.onJump += Jump;
    }

    private void OnDisable()
    {
        Controls.onJump -= Jump;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;

        canShoot = true;
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
        if (canShoot)
        {
            Instantiate(_bulletPref, new Vector3(transform.position.x + 2f, transform.position.y,0),Quaternion.identity);
            canShoot = false;
            StartCoroutine(ShootReload());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Dead") || col.collider.CompareTag("Enemy"))
        {
            onDead?.Invoke();
        }
    }

    private IEnumerator ShootReload()
    {
        yield return new WaitForSeconds(_timeReload);
        canShoot = true;
    }
}
