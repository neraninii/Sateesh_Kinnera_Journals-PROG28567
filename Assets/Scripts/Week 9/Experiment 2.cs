using System.Collections.Generic;
using UnityEngine;

public class Experiment2 : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public List<Collider2D> squares = new List<Collider2D>();

    public int numberOfSquares;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfSquares = rb2D.GetContacts(squares);

         if (numberOfSquares > 0)
        {
            //Debug.Log("Contact Made");
        }

    }
}
