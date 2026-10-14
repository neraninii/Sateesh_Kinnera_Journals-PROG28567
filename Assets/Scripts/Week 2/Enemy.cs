using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class Enemy : MonoBehaviour
{
    public int randomAsteroid;
    public float speed = 0;
    public float motion = 0;
    public List<Transform> asteroidTransforms;
    Vector3 asteroidPos;

    public Transform player; 
    public float maxSpeed = 1f; 
    public float accelerationTime = 1f;

    public float acceleration;

    public Vector3 velocity;
    public float angularSpeed;

    public GameObject enemyBombPrefab;

    public float timer;
    
    private void Update()
    {
        
        //RandomAsteroidWarp();

        PlayerFollowing(); 
        PlayerDetection();
    }

    /**public void RandomAsteroidWarp()
    {
        //conditional to reset the motion to 0 as well as generate a new asteroid to move to every key press
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            //randomly assigning an asteroid to the target position of the enemy
            randomAsteroid = Random.Range(0, 10); 
            asteroidPos = asteroidTransforms[randomAsteroid].position; 

            motion = 0; 
        }
        
        //adding time to the motion for the linear interpolation 
        motion += Time.deltaTime * 0.02f;

        //linear interpolation for the movement from the start and end positions
        Vector3 currentPosition = Vector3.Lerp(transform.position, asteroidPos, motion); 

        //moving the enemy to the randomly chosen asteroid's location 
        transform.position = currentPosition * speed;
        

    }**/

    public void PlayerFollowing()
    {
        acceleration = maxSpeed/accelerationTime; 

        Vector3 direction = (player.position - transform.position).normalized; 

        velocity += Time.deltaTime * direction * acceleration;

        transform.position += Time.deltaTime * velocity;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = maxSpeed * velocity.normalized;
        }
        
    }

    public void PlayerDetection()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float deltaAngle = ComputeShortestAngle(transform.up, direction);

        float rotateDirection = Mathf.Sign(deltaAngle);
        float angleStep = angularSpeed * Time.deltaTime;

        if (angleStep < Mathf.Abs(deltaAngle))
        {
            transform.Rotate(0, 0, rotateDirection * angularSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, deltaAngle);
        }

         timer += Time.deltaTime;


        if (timer > 3)
        {
            Instantiate(enemyBombPrefab, transform.position + transform.up, Quaternion.identity);
            timer = 0;

        }


    }

    private float ComputeShortestAngle(Vector3 a, Vector3 b)
    {
        float angleA = Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg;
        float angleB = Mathf.Atan2(b.y, b.x) * Mathf.Rad2Deg;

        return Mathf.DeltaAngle(angleA, angleB);
    }

}
