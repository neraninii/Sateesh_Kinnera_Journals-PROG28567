using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotion : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public Transform player; 
    public List<GameObject> powerUps;
    public float accelerationTime = 1f;
    public float decelerationTime = 1f;
    public float maxSpeed = 1f;

    [Tooltip("Measured in Degrees per second")]
    public float angularSpeed = 90f; 

    private float acceleration;
    private float deceleration;
    private Vector3 velocity = Vector3.zero; 

    public float orbitalRadius = 3f; 
    public float orbitalSpeed = 2f;

    public float angle; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        acceleration = maxSpeed/accelerationTime;
        deceleration = maxSpeed/decelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        playerPowerUp();
    }

    private void PlayerMovement()
    {
        Vector3 playerInput = Vector3.zero; 
        Keyboard kbd = Keyboard.current;

        if(kbd.leftArrowKey.isPressed || kbd.aKey.isPressed)
        {
            playerInput += Vector3.left; 
        }

        if(kbd.rightArrowKey.isPressed || kbd.dKey.isPressed)
        {
            playerInput += Vector3.right; 
        }

        if(kbd.upArrowKey.isPressed || kbd.wKey.isPressed)
        {
            playerInput += Vector3.up; 
        }

        if(kbd.downArrowKey.isPressed || kbd.sKey.isPressed)
        {
            playerInput += Vector3.down; 
        }

        if (playerInput.sqrMagnitude > 0) //some input detected
        {
            velocity += acceleration * Time.deltaTime * playerInput.normalized; //accelerate relative to input

            if (velocity.sqrMagnitude > maxSpeed * maxSpeed) //going too fast
            {
                velocity = Vector3.ClampMagnitude(velocity, maxSpeed); //enforce speed limit
            } 
        }
        else //no input detected 
        {
            float deltaVelocity = deceleration * Time.deltaTime; //deceleration this frame

            if (velocity.magnitude > deltaVelocity) // if we still need to slow down
            {
                velocity -= deltaVelocity * velocity.normalized; //decelerate 
            }
            else //close enough to stop
            {
                velocity = Vector3.zero; //complete stop 
            }
        }

        transform.position += Time.deltaTime * velocity; // move relative to velocity
    }


    private void PlayerRotation()
    {
        if (velocity.sqrMagnitude == 0) return; //not moving, do nothing

        float deltaAngle = ComputeShortestAngle(transform.up, velocity);

        if (deltaAngle == 0 ) return; //locked on, do nothing

        float rotationDirection = Mathf.Sign(deltaAngle); //returns the positive or negative of a value
        float rotationStep = angularSpeed * Time.deltaTime; 

        if (rotationStep < Mathf.Abs(deltaAngle)) //returns number without negative or positive //if we still need to rotate
        {
            transform.Rotate(0,0, rotationStep * rotationDirection); 
        }
        else //close enough to lock on 
        {
            transform.Rotate(0, 0, deltaAngle); //lock on
        
        }

    }

    private float ComputeShortestAngle(Vector3 a, Vector3 b)
    {
        float angleA = Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg;
        float angleB = Mathf.Atan2(b.y, b.x) * Mathf.Rad2Deg; 

        return Mathf.DeltaAngle(angleA, angleB);


    }

    public void playerPowerUp()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            GameObject powerUp = Instantiate(powerUpPrefab, transform.position + transform.up, Quaternion.identity); 
            powerUp.GetComponent<PowerUp>().player = transform;
        }


    }
}
