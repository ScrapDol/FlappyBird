using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private int _score = 0;

    private void OnEnable()
    {
        Asteroid.onDead += ScoreUpdate;
    }

    private void OnDisable()
    {
        Asteroid.onDead -= ScoreUpdate;
    }

    private void ScoreUpdate()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
