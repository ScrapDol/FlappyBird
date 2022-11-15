using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public static Action onJump;
    
    [SerializeField] private KeyCode keyJump;

    private void Update()
    {
        if (Input.GetKeyDown(keyJump))
        {
            onJump?.Invoke();
        }
    }
}
