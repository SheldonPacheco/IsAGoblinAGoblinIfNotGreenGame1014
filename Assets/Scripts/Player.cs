using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 8f;
    public float meleeAttackRange = 1f;
    public LayerMask enemyLayer; 
    public Color currentColor = Color.white;
    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;
    private bool isFacingRight = true;
    private Animator animator;
    public static Vector3 position;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
        HandleMovement();

        
        HandleAttacks();
        HandleMagic();
        HandleJumping();
        position = transform.position;
    }
    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        rb.velocity = movement;

        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            FlipSprite();
        }

        isGrounded = col.IsTouchingLayers(LayerMask.GetMask("Ground"));
        bool isWalkingThisFrame = Mathf.Abs(horizontalInput) > 0;

        animator.SetBool("Walking", isWalkingThisFrame);



        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HandleAttacks()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }
    }
    private void HandleMagic()
    {

        if (Input.GetMouseButtonDown(1))
        {
            MagicAttack();
        }

    }
    private void HandleJumping()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2f - 1) * Time.deltaTime;
        }
    }
    private void MeleeAttack()
    {
        animator.SetTrigger("MeleeAttack");
        animator.Play("MeleeAttack");
        PerformRaycast();
    }

    private void MagicAttack()
    {
        animator.SetTrigger("CastMagic");
        animator.Play("CastMagic");
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeAttackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            StatSystem.Instance.goblinKills++;
            Destroy(enemy.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goblin"))
        {
            
        }
    }
}