using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject goblin;
    public float spawnRate = 2f;
    public Transform spawnPoint;
    public float wanderRadius = 1f; // Adjust this to match Enemy's wander radius
    public int spawnCount = 0;
    public static EnemySpawner Instance { get; private set; }
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    public void SpawnEnemy()
    {
        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            if (spawnCount <= 6)
            {
                
                Instantiate(goblin, spawnPoint.position, Quaternion.identity);
                spawnCount++;
            }
        }
    }
}