using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D; 
    public float moveSpeed = 5f;

    public FacingDirection currentDirection;

    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Vector2 playerInput = new Vector2();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        if (Keyboard.current.aKey.isPressed)
        {
            playerInput.x = -1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            playerInput.x = 1;
        }

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {

        rb2D.linearVelocityX = playerInput.x * moveSpeed;
    }

    public bool IsWalking()
    {
        if (rb2D.linearVelocityX != 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool IsGrounded()
    {
        return false;
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
