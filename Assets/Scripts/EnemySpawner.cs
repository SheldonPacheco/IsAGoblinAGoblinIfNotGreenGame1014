using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject goblin; 
    public float spawnRate = 2f; 
    public Transform spawnPoint; 

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    private void SpawnEnemy()
    {
        Instantiate(goblin, spawnPoint.position, Quaternion.identity);
    }
}
