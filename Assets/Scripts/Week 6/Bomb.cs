
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player; 
    public float speed;
    public float time;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHit();
    }

    public void PlayerHit()
    {
        time += Time.deltaTime * speed;

        Vector3 newPos = Vector3.Lerp(transform.position, player.position, speed);

        transform.position = newPos; 
         
    } 
}
