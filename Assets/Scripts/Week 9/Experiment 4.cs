using UnityEngine;

public class Experiment4 : MonoBehaviour
{
    public Collider2D triangleCollider; 
    public ContactFilter2D contactFilter; 
    public Collider2D[] overlappedObjects = new Collider2D[5];

    public int overlapCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        overlapCount = Physics2D.OverlapCollider(triangleCollider, contactFilter, overlappedObjects);

        for(int i = 0; i < overlapCount; i++)
        {
            Debug.Log("overlap");
        }
    }
}
