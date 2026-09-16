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

    }

    void bombOffset(Vector3 offset)
    {
        Instantiate(bombPrefab, transform.position + offset, Quaternion.identity);
    }
}
