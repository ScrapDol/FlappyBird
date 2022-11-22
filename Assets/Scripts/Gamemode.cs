using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gamemode : MonoBehaviour
{
    [SerializeField] private GameObject _defaultBird;
    [SerializeField] private GameObject _playButton;
    private GameObject _currentBird;
    private GameObject _birdInGame;

    private void Awake()
    {
        if (_currentBird == null)
        {
            _currentBird = _defaultBird;
        }

        _birdInGame = Instantiate(_currentBird, new Vector2(-8.5f, 0), Quaternion.identity);
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        Bird.onDead += DeathOfTheBird;
    }

    private void OnDisable()
    {
        Bird.onDead -= DeathOfTheBird;
    }

    private void DeathOfTheBird()
    {
        Destroy(_birdInGame);
        Time.timeScale = 0;
        _playButton.SetActive(true);
    }
}
