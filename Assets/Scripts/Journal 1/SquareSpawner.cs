using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public float size = 1f;
    public Vector2 LastMousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 square1 = new Vector2(-0.5f * size, -0.5f * size);
        Vector2 square2 = new Vector2(0.5f * size, 0.5f * size);
        Vector2 square3 = new Vector2(-0.5f * size, 0.5f * size);
        Vector2 square4 = new Vector2(0.5f * size, -0.5f * size);



        //a. Create a script called SquareSpawner.cs. When you click on the screen, it should draw a white square at the position you clicked on the screen using Debug.DrawLine.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.DrawLine(square1 + mousePos, square3 + mousePos, Color.white);
            Debug.DrawLine(square3 + mousePos, square2 + mousePos, Color.white);
            Debug.DrawLine(square2 + mousePos, square4 + mousePos, Color.white);
            Debug.DrawLine(square4 + mousePos, square1 + mousePos, Color.white);

            LastMousePos = mousePos;

        }

            Debug.DrawLine(square1 + LastMousePos, square3 + LastMousePos, Color.white);
            Debug.DrawLine(square3 + LastMousePos, square2 + LastMousePos, Color.white);
            Debug.DrawLine(square2 + LastMousePos, square4 + LastMousePos, Color.white);
            Debug.DrawLine(square4 + LastMousePos, square1 + LastMousePos, Color.white);


        // b. Draw a semi-transparent square at the position of the mouse at all times.

        transform.position = mousePos;
        transform.localScale = Vector3.one * size;

        //c. When you scroll using the mouse wheel, it should increase/decrease the size of the semi-transparent square and any squares that you spawn into the scene.

        Vector2 scrollValue = Mouse.current.scroll.ReadValue();
        size += scrollValue.y * 0.1f;


    }
}
