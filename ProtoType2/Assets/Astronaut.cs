using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public Transform airShip;
    private Rigidbody2D rb;
    public Vector3 direction;
    public float moveSpeed = 5;
    public float distance = 0;
    public bool dragging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = airShip.position - transform.position;
        direction.Normalize();
        
            
    }

    private void FixedUpdate()
    {
        moveCharacter();
        distance = Mathf.Sqrt(Mathf.Pow((airShip.position.x - transform.position.x),2) + Mathf.Pow((airShip.position.y - transform.position.y),2));
    }

    void moveCharacter()
    {

        if (distance > 10f) {
            rb.velocity = Vector2.zero;
            rb.MovePosition(transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
            // rb.AddForceAtPosition(direction * moveSpeed, transform.position);  
        }
        // // rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        else {

            rb.velocity = direction * moveSpeed;
        }

        Color color = new Color(0f, 0f, 1.0f);
        Debug.DrawLine(transform.position, transform.position + direction, color);

        Debug.Log(rb.velocity);
        
    }
}