using UnityEngine;
using UnityEngine.InputSystem;

public class Experiment3 : MonoBehaviour
{
    public Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
           if(rb2D.OverlapPoint(mousePos))
            {
                //Debug.Log("Overlapped");
                rb2D.gravityScale = 1;
            }
            
        }
    }
}
