using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public Vector2 lastMousePos;
    public Vector2 currentMousePos;
    public float time = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //a. Create a script called Pipeline.cs. When the mouse is held down, store the position of the mouse in a variable.
        //b. If the mouse is still held down after 0.1 seconds, you should draw a line from the previous point to the new point of the mouse and store the new point of the mouse. Every 0.1 seconds from then you should draw a line from the current position to the point the mouse was at 0.1 seconds ago.

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.isPressed)
        {
            lastMousePos = mousePos;
            Debug.DrawLine(lastMousePos, currentMousePos, Color.white);
            time += Time.deltaTime;
            if (time >= 0.1f)
            {
                currentMousePos = mousePos;
            }

            //c. When the mouse is released, you should output the total length of the pipeline to the console. *Try to use the magnitude formula covered in class.

            Vector2 lplusc = lastMousePos + currentMousePos;


            float magnitude = Mathf.Sqrt(Mathf.Pow(lplusc.x, 2) + Mathf.Pow(lplusc.y, 2));
            Debug.Log(magnitude);

        }
        else
        {
            time = 0f;
        }



    }
}
