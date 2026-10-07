using UnityEngine;

public class Turret : MonoBehaviour
{
    [Tooltip("Measured in degrees per second")]
    public float angularSpeed;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, angularSpeed * Time.deltaTime);

        Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);

        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.up, directionToTarget);

        if (dotProduct >= 0)
        {
            Debug.Log ("In front");
        }
        else
        {
            Debug.Log("Behind");
        }

    }
}
