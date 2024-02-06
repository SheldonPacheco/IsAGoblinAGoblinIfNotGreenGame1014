using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Color enemyColor = Color.white;
    public int maxHealth = 50;
    public int currentHealth;

    public int minDamage = 2;
    public int maxDamage = 9;

    public float wanderSpeed = 3f;
    public float wanderRadius = 5f;

    private Vector2 wanderPoint;

    private void Start()
    {
        currentHealth = maxHealth;
        GetNewWanderPoint();
    }

    private void Update()
    {
        Wander();
        
    }

    private void Wander()
    {
        transform.Translate(wanderPoint * wanderSpeed * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, wanderPoint) < 0.1f)
        {
            GetNewWanderPoint();
        }
    }

    private void GetNewWanderPoint()
    {
        wanderPoint = (Vector2)transform.position + Random.insideUnitCircle * wanderRadius;
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int DealDamage()
    {
        
        return Random.Range(minDamage, maxDamage + 1);
    }

    private void Die()
    {
        
       
    }
}

