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
    
    private void Update()
    {
        
        RandomAsteroidWarp();
    }

    public void RandomAsteroidWarp()
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
        

    }

}
