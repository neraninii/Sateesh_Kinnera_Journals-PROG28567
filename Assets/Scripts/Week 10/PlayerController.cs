using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D; 
    public float moveSpeed = 5f;

    public FacingDirection currentDirection;

    public List<Collider2D> platforms = new List<Collider2D>();

    public int platformNumber; 

    public Vector2 groundCheckOffset = new (0f, -0.65f);
    public Vector2 groundCheckSize = new(0.5f, 0.1f);
    public LayerMask groundCheckMask; 

    public float maxSpeed = 5f;
    public float accelerationTime = 0.25f;
    public float decelerationTime = 0.15f;

    public float acceleration;
    public float deceleration;
    public Vector2 velocity; 

    public float apexHeight = 3f;
    public float apexTime = 0.5f;

    public float gravity; 
    public float jumpVelocity; 
    public float terminalVelocity; 

    private bool isJumping = false; 
    private bool isGrounded = false;

    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        rb2D.gravityScale = 0;

        acceleration = maxSpeed/accelerationTime;
        deceleration = maxSpeed/decelerationTime; 

        gravity = -2 * apexHeight / Mathf.Pow(apexTime, 2);
        jumpVelocity = 2 * apexHeight / apexTime;
        terminalVelocity = gravity;

        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //contactCheck();
        CheckForGround();
        
        Vector2 playerInput = new ();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        if (Keyboard.current.aKey.isPressed)
        {
            playerInput.x += -1;
            //playerInput.x = -1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            playerInput.x += 1;
            //playerInput.x = 1;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            isJumping = true; 
        }

        MovementUpdate(playerInput);
    }

    public void FixedUpdate()
    {
        if (!isGrounded)
        {
            velocity.y += gravity * Time.fixedDeltaTime; 
            velocity.y = Mathf.Clamp(velocity.y, terminalVelocity, velocity.y);
        }
        else
        {
            velocity.y = 0;
        }

        if (isJumping)
        {
            velocity.y = jumpVelocity; 
            isJumping = false; 
        }

         rb2D.linearVelocity = velocity;
  
    } 

    public void CheckForGround()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + (Vector3)groundCheckOffset, groundCheckSize, 0, groundCheckMask); 
    }

    private void MovementUpdate(Vector2 playerInput)
    {

        //rb2D.linearVelocityX = playerInput.x * moveSpeed;

        if (playerInput.x != 0)
        {
            velocity.x += acceleration * playerInput.x * Time.deltaTime; 
            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime); 
        }
    }

    public bool IsWalking()
    {
        /* if (rb2D.linearVelocityX != 0)
        {
            return true;
        }
        else
        {
            return false;
        } */ 

        return velocity.x != 0;

    }

    public void contactCheck()
    {
        platformNumber = rb2D.GetContacts(platforms);

    }
    public bool IsGrounded()
    {
        /* if (platformNumber > 0)
        {
            return true;
        }
        else
        {
            return false;
        } */

        return isGrounded; 


    }

    public FacingDirection GetFacingDirection()
    {
        if (rb2D.linearVelocityX > 0)
        {
            currentDirection = FacingDirection.right;
        }
        else if (rb2D.linearVelocityX < 0)
        {
            currentDirection = FacingDirection.left;
        }
        
        return currentDirection;
      
    }

}
