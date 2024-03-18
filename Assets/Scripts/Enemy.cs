using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public Color enemyColor = Color.green;
    public int maxHealth = 50;
    public int currentHealth;

    public int minDamage = 2;
    public int maxDamage = 9;

    public float wanderSpeed = 1f;
    public float timer;
    private Vector2 SpawnPoint;

    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public RaycastHit2D hit;
    public float distanceFromPlayer;
    Vector2 direction;
    private void Start()
    {
        currentHealth = maxHealth;
        SpawnPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 3.0f;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Wander();
        CheckCollision();
    }

    private void Wander()
    {
        if (movingRight)
        {
            animator.SetBool("Walking", true);
            spriteRenderer.flipX = false;

            transform.Translate(Vector2.right * wanderSpeed * Time.deltaTime);
            if (Vector2.Distance(SpawnPoint, transform.position) > 5.0f)
            {
                movingRight = false;

              
            }
        }
        else if (!movingRight) {
            animator.SetBool("Walking", true);
            spriteRenderer.flipX = true;
            transform.Translate(Vector2.left * wanderSpeed * Time.deltaTime);
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                if (Vector2.Distance(SpawnPoint, transform.position) > 3.0f)
                {
                    movingRight = true;
                    timer = 3.0f;


                }
            }
        }
        else {
            animator.SetBool("Walking", false);
        }
    }

    private void CheckCollision()
    {
        direction = movingRight ? Vector2.right : Vector2.left;

        
        hit = Physics2D.Raycast(transform.position, direction, 3.0f);

        
        Debug.DrawRay(transform.position, direction * 3.0f, Color.red);

        
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            animator.SetBool("MeleeAttack", true);
        }
        else
        {
            animator.SetBool("MeleeAttack", false);
        }
    }
}