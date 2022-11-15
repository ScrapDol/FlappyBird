using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public static Action onDead;
    [SerializeField] private float _jumpForce;
    
    private Rigidbody2D _rigidbody;

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
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Dead"))
        {
            onDead?.Invoke();
        }
    }
}
