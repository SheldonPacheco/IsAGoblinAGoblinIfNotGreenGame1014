using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject goblin;
    public float spawnRate = 2f;
    public Transform spawnPoint;
    public float wanderRadius = 1f; // Adjust this to match Enemy's wander radius

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    private void SpawnEnemy()
    {
        Instantiate(goblin, spawnPoint.position, Quaternion.identity);

    }
}