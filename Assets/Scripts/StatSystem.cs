using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class StatSystem
{
    
    public static int playerMaxHealth = 100;
    public static int playerCurrentHealth;
    public static int playerExperiencePoints = 0;
    public static int playerLevel = 1;
    public static int playerGold = 0;

   
    public static int enemyMaxHealth = 50;
    public static int enemyMinDamage = 2;
    public static int enemyMaxDamage = 9;

    static StatSystem()
    {
        ResetPlayerStats();
    }

    public static void ResetPlayerStats()
    {
        playerCurrentHealth = playerMaxHealth;
        playerExperiencePoints = 0;
        playerLevel = 1;
        playerGold = 0;
    }

    public static void TakeDamage(int Health, int damage)
    {
        
        Health -= damage;

        
        if (Health <= 0)
        {
           // GameObject.Destroy();
        }
    }

    public static int DealDamage(int minDamage, int maxDamage)
    {
        
        return Random.Range(minDamage, maxDamage + 1);
    }
}