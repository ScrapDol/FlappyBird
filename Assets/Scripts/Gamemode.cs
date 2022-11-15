using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{
    [SerializeField] private GameObject _defaultBird;
    private GameObject _currentBird;
    private GameObject _birdInGame;

    private void Awake()
    {
        if (_currentBird == null)
        {
            _currentBird = _defaultBird;
        }

        _birdInGame = Instantiate(_currentBird);
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        Bird.onDead += DeathOfTheBird;
    }

    private void DeathOfTheBird()
    {
        Destroy(_birdInGame);
        Time.timeScale = 0;
    }
}
