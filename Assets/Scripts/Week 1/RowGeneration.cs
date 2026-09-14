using UnityEngine;
using TMPro;

public class RowGeneration : MonoBehaviour
{
    public int squares = 1; 
    public TMP_InputField SquareNumber;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //a. Create a script called RowGeneration.cs. In the scene, create a UI button with the text “GENERATE” on it and call the object GenerateButton. Create an InputField called SquareNumberInput.

        Vector2 square1 = new Vector2(-0.5f, -0.5f);
        Vector2 square2 = new Vector2(0.5f, 0.5f);
        Vector2 square3 = new Vector2(-0.5f, 0.5f);
        Vector2 square4 = new Vector2(0.5f, -0.5f);

        Debug.DrawLine(square1, square3, Color.white);
        Debug.DrawLine(square3, square2, Color.white);
        Debug.DrawLine(square2, square4, Color.white);
        Debug.DrawLine(square4, square1, Color.white);

    }

    public void GenerateSquares()
    {
         //b. When the generate button is pressed, you should draw a row of squares side-by-side in the scene using Debug.DrawLine. It should have the number of squares specified in the InputField.

        if (int.TryParse(SquareNumber.text, out squares))
        {
            for (int i = 0; i < squares; i++)
            {
                Vector2 square1 = new Vector2(-0.5f, -0.5f);
                Vector2 square2 = new Vector2(0.5f, 0.5f);
                Vector2 square3 = new Vector2(-0.5f, 0.5f);
                Vector2 square4 = new Vector2(0.5f, -0.5f);

                square1 += new Vector2(i, 0);
                square2 += new Vector2(i, 0);
                square3 += new Vector2(i, 0);
                square4 += new Vector2(i, 0);

                Debug.DrawLine(square1, square3, Color.white);
                Debug.DrawLine(square3, square2, Color.white);
                Debug.DrawLine(square2, square4, Color.white);
                Debug.DrawLine(square4, square1, Color.white);


            }
        }
         //c. Add in a check that confirms that the value SquareNumberInput is valid before attempting to generate the squares.
        else
        {
            Debug.Log("Please enter a valid number.");
        }

    }
}
