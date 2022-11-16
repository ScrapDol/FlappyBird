using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _speed;
    private void OnEnable()
    {
        Bullet.onHit += Dead;
    }

    private void OnDisable()
    {
        Bullet.onHit -= Dead;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * (_speed * Time.fixedDeltaTime));
    }

    private void Dead(GameObject gameObject)
    {
        _hp--;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
