using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private Vector3 currentPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public int nextStar = 0;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    private void DrawConstellation()
    {
        //creating variables for the starting and ending stars
        int startingStar = nextStar;
        int endingStar = startingStar + 1;

        //assigning the Vector3 positions for the stars
        startPosition = starTransforms[startingStar].position; 
        endPosition = starTransforms[endingStar].position;

        //adding time to Drawing Time
        drawingTime += Time.deltaTime; 

        //using linear interpolation to animate the debug.DrawLine 
        currentPosition = Vector3.Lerp(startPosition, endPosition, drawingTime);
        Debug.DrawLine(startPosition, currentPosition, Color.blue);
        
        //conditional to move onto next star
         if (drawingTime > 1)
        {
            nextStar++;
            drawingTime = 0;

        }

        //conditional to reset to the beginning of the constellation
        if (nextStar == 6)
        {
            nextStar = 0;
        }

        

    }
}
