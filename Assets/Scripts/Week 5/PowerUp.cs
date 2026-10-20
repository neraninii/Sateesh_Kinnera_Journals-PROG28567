using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public Transform player;

    public float orbitalRadius = 3f; 
    public float orbitalSpeed = 2f;

    public float angle; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitalRadius, orbitalSpeed, player);
    }

    //Rotation Mechanic 2: Power Up Orbit

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
