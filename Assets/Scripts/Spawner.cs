using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeSpawn;
    [SerializeField] private List<GameObject> AsteroidPrefs;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeSpawn);
            int rand = Random.Range(0, AsteroidPrefs.Count);
            Instantiate(AsteroidPrefs[rand], new Vector2(13f, Random.Range(4.2f,-4.2f)), Quaternion.identity);
        }
    }
}
