

using UnityEngine;
using UnityEngine.InputSystem;

public class DotProductExercise : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 redVector = ComputerVectorFromAngle(redAngle);
        Vector3 blueVector = ComputerVectorFromAngle(blueAngle);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            float dotProduct = ComputeDotProduct(redVector, blueVector);

            if (dotProduct <= float.Epsilon) //or 0.001f
            {
                dotProduct = 0;
            }
            
            Debug.Log(dotProduct);
        }
    }

    public Vector3 ComputerVectorFromAngle(float angle)
    {
        float angleInRads = angle * Mathf.Deg2Rad;


        float x = Mathf.Cos(angleInRads);
        float y = Mathf.Sin(angleInRads);

        return new Vector3(x, y, 0);
    }

    public float ComputeDotProduct(Vector3 a, Vector3 b)
    {
        float dot = a.x * b.x + a.y * b.y + a.z * b.z;
        return dot;
    }
}
