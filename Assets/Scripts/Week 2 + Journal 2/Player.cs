using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
    public int NumberOfBombs; 

    public float ratio;

    // Update is called once per frame
    void Update()
    {

        // Checking if bomb spawns above player
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            bombOffset(Vector3.up);
        }

        
        // Checking if points are normalized
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.Log(normalize(new Vector2(3,4)));
            Debug.Log(normalize(new Vector2(-3,2)));
            Debug.Log(normalize(new Vector2(1.5f,3.5f)));
        }

        //Checking if bomb trail spawns below player
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(0, NumberOfBombs);
        }

        //Checking if bomb spawns on a random corner of the player
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SpawnBombOnRandomCorner(1.5f);
        }

        //Checking if player warps to enemy
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            warpPlayer(enemyTransform, ratio);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            DetectAsteroids(3, asteroidTransforms);
        }

    }

    // Spawning a bomb above the player using methods and offsets
    void bombOffset(Vector3 offset)
    {
        Instantiate(bombPrefab, transform.position + offset, Quaternion.identity);
    }

    // Normalizing points using the formula
    Vector2 normalize(Vector2 inVector)
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(inVector.x, 2) + Mathf.Pow(inVector.y, 2));
        Vector2 outVector = new Vector2(inVector.x / magnitude, inVector.y / magnitude);

        return outVector;
    }

    //Spawning a bomb trail below player 
    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        // For Loop that spawns bombs based on inputted value
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            // Offset for each bomb 
            inBombSpacing += 1;
            Vector3 bombPosition = transform.position + Vector3.down * inBombSpacing;
            Instantiate(bombPrefab, bombPosition, Quaternion.identity);
        }
    }

    //Spawning a bomb on a random corner of the player
    public void SpawnBombOnRandomCorner(float inDistance)
    {
        // variable to generate a randoom number that will determine which corner
        int corner = Random.Range(0, 4);

        //Conditional statements to determine the corner where the bomb will be spawnedaccording to the random number
         if (corner == 0)
        {
            Instantiate(bombPrefab, transform.position + Vector3.up + Vector3.left * inDistance, Quaternion.identity);
        }
        else if (corner == 1)
        {
            Instantiate(bombPrefab, transform.position + Vector3.up + Vector3.right * inDistance, Quaternion.identity);
        }
        else if (corner == 2)
        {
            Instantiate(bombPrefab, transform.position + Vector3.down + Vector3.left * inDistance, Quaternion.identity);
        }
        else if (corner == 3)
        {
            Instantiate(bombPrefab, transform.position + Vector3.down + Vector3.right * inDistance, Quaternion.identity);
        }
            
    }

    //Warping player to the enemy
    void warpPlayer(Transform target, float ratio)
    {

        Vector3 newPos = Vector3.Lerp(transform.position, target.position, ratio);
        transform.position = newPos;

    }


    //Detecting asteroids with Debug.DrawLine
     public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {

        //Creating a for loop to get the Vector3 positions of each asteroid in the list
        for (int i = 0; i < inAsteroids.Count; i++) 
        {
            Vector3 asteroidsPos = inAsteroids[i].position; 

            //Setting a range from the player position
            float playerX = inMaxRange + transform.position.x;
            float playerY = inMaxRange + transform.position.y;

            //Conditional to draw line from player
            if (asteroidsPos.y < playerY && asteroidsPos.y > -playerY && asteroidsPos.x < playerX && asteroidsPos.x > -playerX)
            {
                Debug.DrawLine(transform.position, asteroidsPos, Color.green);
            }

            
        }
    }

    

}
