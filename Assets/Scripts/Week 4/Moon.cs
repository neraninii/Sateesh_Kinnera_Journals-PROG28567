using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    public float orbitalRadius = 3f; 
    public float orbitalSpeed = 2f;

    public float angle; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitalRadius, orbitalSpeed, planetTransform);

    }

    //Orbiting the moon around the planet
    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        angle += Time.deltaTime * speed; 
        float angleInRads = angle * Mathf.Deg2Rad;

        float xPos = Mathf.Cos(angleInRads);
        float yPos = Mathf.Sin(angleInRads);

        Vector3 offset = new Vector3(xPos, yPos, 0f);

        transform.position = target.position + offset * radius;

        
    }
}
