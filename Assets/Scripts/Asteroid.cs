using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public static Action onDead;
    
    [SerializeField] private float _hp;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.left * (_speed * Time.deltaTime));
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _hp--;
        if (_hp <= 0)
        {
            onDead?.Invoke();
            Destroy(gameObject);
        }
    }
}
