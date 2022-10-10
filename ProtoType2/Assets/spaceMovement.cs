using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public GameObject bullet;
    //public Transform shootPoint;
    public float recoilForce;
    
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        Vector2 lookDir = mousePos - rb.position;

        //Instantiate(bullet, mousePos, transform.rotation);

        rb.AddForce(-lookDir * recoilForce, ForceMode2D.Force);
    }
}
