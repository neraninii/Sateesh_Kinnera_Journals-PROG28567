using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
    public int inNumberOfBombs; 
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

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(1, inNumberOfBombs);
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

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            inBombSpacing += 1;
            Vector3 bombPosition = transform.position + Vector3.down * inBombSpacing;
            Instantiate(bombPrefab, bombPosition, Quaternion.identity);
        }
    }

    void warpPlayer(Transform target, float ratio)
    {
        
    }
}
