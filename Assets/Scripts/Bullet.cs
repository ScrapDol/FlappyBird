using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public static Action<GameObject> onHit;

    [SerializeField] private float _lifeTime;
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        StartCoroutine(LifePeriodic());
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.right * (speed * Time.fixedDeltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            onHit?.Invoke(col.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator LifePeriodic()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(this.gameObject);
    }
}
