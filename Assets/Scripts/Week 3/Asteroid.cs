using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public bool chooseRandom = true;
    public Vector3 randomDirection;
    public Vector3 randomPos;

    public float x; 
    public float y;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Checking asteroid movement
        if (Keyboard.current.aKey.isPressed)
        {
          AsteroidMovement();  
        }
        
    }

    public void AsteroidMovement()
    {
        // conditional to check when to choose new random points with a boolean
        if (chooseRandom == true)
        {
            // choosing new points randomly
            x = Random.Range(-1,1);
            y = Random.Range(-1,1);

            //inserting them in a Vector3
            randomDirection = new Vector3(x, y);

            //using the maxFloatDistance value to get the random target position for the asteroids 
            randomPos = maxFloatDistance * randomDirection.normalized + transform.position;

            //setting boolean to false as new points are not needed
            chooseRandom = false;
        }

        //getting the distance between the random target position and the asteroids 
        float randomDistance = Vector3.Distance(transform.position, randomPos);

        //condiitonal to check whether the asteroid is near the arrival distance of the random target
        if (randomDistance > arrivalDistance)
        {
            //moving the asteroid towards the direction of the random target position
            transform.position += Time.deltaTime * moveSpeed * randomDirection;
        }
        else
        {
            //choosing new random points
            chooseRandom = true;
        }




    }


}
