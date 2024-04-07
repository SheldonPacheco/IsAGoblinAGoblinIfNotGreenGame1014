using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public Color enemyColor = Color.green;
    public int maxHealth = 100;
    public int currentHealth = 100;

    public int minDamage = 2;
    public int maxDamage = 9;

    public float wanderSpeed = 1f;
    public float timer;
    private Vector2 SpawnPoint;

    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;
    public static Animator animator;
    public RaycastHit2D hit;
    public float distanceFromPlayer;
    Vector2 direction;
    float attackTimer = 3.0f;
    public Slider hpBar;
    public TMP_Text hpBarText;
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
        hpBar.value = currentHealth;
        hpBarText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

    private void Wander()
    {
        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            if (movingRight)
            {
                if (animator != null)
                {
                    animator.SetBool("Walking", true);
                }
                spriteRenderer.flipX = false;

                transform.Translate(Vector2.right * wanderSpeed * Time.deltaTime);
                if (Vector2.Distance(SpawnPoint, transform.position) > 5.0f)
                {
                    movingRight = false;
                }
            }
            else if (!movingRight)
            {
                if ( animator != null){
                    animator.SetBool("Walking", true);
                } 
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
            else
            {
                if (animator != null)
                {
                    animator.SetBool("Walking", false);
                }
            }
        }
    }

    private void CheckCollision()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0.0f)
        {
            direction = movingRight ? Vector2.right : Vector2.left;


            hit = Physics2D.Raycast(transform.position, direction, 1.0f);


            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                  if (animator != null)
                  {
                    animator.SetBool("MeleeAttack", true);
                  }
                    
                StatSystem.Instance.TakeDamage(hit.collider.gameObject.GetComponent<Player>().gameObject, StatSystem.Instance.DealDamage(5, 8));

                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector3.up * 5.1f);
                
                if (hit.collider.gameObject.GetComponent<Player>().currentHealth <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    Destroy(hit.collider.gameObject);
                }
                attackTimer = 3.0f;
            }
            else
            {
                if (animator != null)
                    animator.SetBool("MeleeAttack", false);
            }
            
        } else if (attackTimer > 0.0f)
        {
            if (animator != null)
                animator.SetBool("MeleeAttack", false);
        }
        
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
}