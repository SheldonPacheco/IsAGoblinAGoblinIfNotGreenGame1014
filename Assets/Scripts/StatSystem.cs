using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StatSystem : MonoBehaviour
{
    
    public int playerMaxHealth = 100;
    public int playerCurrentHealth = 100;
    public int playerExperiencePoints = 0;
    public int playerLevel = 1;
    public int playerGold = 0;

    public int enemyMaxHealth = 80;
    public int enemyCurrentHealth = 80;
    public int enemyMinDamage = 2;
    public int enemyMaxDamage = 9;

    public GameObject level;
    public Sprite levelState1;
    public Sprite levelState2;
    public Sprite levelState3;
    public int goblinKills;

    public static StatSystem Instance { get; private set; }
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public  void ResetPlayerStats()
    {
        playerCurrentHealth = playerMaxHealth;
        playerExperiencePoints = 0;
        playerLevel = 1;
        playerGold = 0;
    }
    private void Update()
    {
        ColourLevel();
    }
    public void TakeDamage(int Health, int damage)
    {
        
        Health -= damage;

        
        if (Health <= 0)
        {
           // GameObject.Destroy();
        }
    }

    public  int DealDamage(int minDamage, int maxDamage)
    {
        
        return Random.Range(minDamage, maxDamage + 1);
    }
    public void ColourLevel()
    {
        
        if (goblinKills == 6)
        {

            level.GetComponent<SpriteRenderer>().sprite = levelState3;
        } else if (goblinKills == 4)
        {
            level.GetComponent<SpriteRenderer>().sprite = levelState2;
        }
        else if (goblinKills == 2)
        {
            level.GetComponent<SpriteRenderer>().sprite = levelState1;
        }
    }
    
}