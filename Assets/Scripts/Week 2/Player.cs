using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            bombOffset(Vector3.up);
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.Log(normalize(new Vector2(3,4)));
            Debug.Log(normalize(new Vector2(-3,2)));
            Debug.Log(normalize(new Vector2(1.5f,3.5f)));
        }

    }

    void bombOffset(Vector3 offset)
    {
        Instantiate(bombPrefab, transform.position + offset, Quaternion.identity);
    }

    Vector2 normalize(Vector2 inVector)
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(inVector.x, 2) + Mathf.Pow(inVector.y, 2));
        Vector2 outVector = new Vector2(inVector.x / magnitude, inVector.y / magnitude);

        return outVector;
    }
}
