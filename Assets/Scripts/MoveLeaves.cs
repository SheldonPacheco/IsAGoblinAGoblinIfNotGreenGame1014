using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeaves : MonoBehaviour
{
    
    public float moveSpeed = 3f;
    private Vector3 originalPosition;
    private float movementTimerToDownMovement = 0f;
    private float movementDownTimer = 0f;
    private float movementResetTimer = 0;

    private bool continueMoving = true;
    private Animator animator;

    void Start()
    {
        originalPosition = transform.position;
        continueMoving = true;
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (continueMoving)
        {
            
            MoveLeft();
            movementTimerToDownMovement += Time.deltaTime;

           
            if (movementTimerToDownMovement >= 0.75f)
            {
                MoveDown();
                
               
            }
        }
        else if (!continueMoving)
        {
            
            movementResetTimer += Time.deltaTime;

            if (movementResetTimer >= 2.0f)
            {
                
                transform.position = originalPosition;
                movementTimerToDownMovement = 0f;
                movementResetTimer = 0f;
                movementDownTimer = 0f;
                
                continueMoving = true;
                animator.Play("Idle");
            }
        }
    }

    
    void MoveLeft()
    {       
        if (animator.HasState(0, Animator.StringToHash("Leaves")))
        {
            animator.Play("Leaves");
        }
        if (animator.HasState(0, Animator.StringToHash("ColouredLeaves")))
        {
            animator.Play("ColouredLeaves");
        }

        moveSpeed = 3f;
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    
    void MoveDown()
    {
        
        moveSpeed = 2f;
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

      
        movementDownTimer += Time.deltaTime;
        if (movementDownTimer >= 0.5f)
        {
            continueMoving = false;
            

        }
    }
}
