using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private float maxSpeed = 0.2f;

    private Rigidbody2D rb;

    float maxVelocity = 3;

    public float rotationSpeed = 3;
    public float decreaseSpeed = 2.0f;
    Vector2 direction;
    private void Start()
    {
        mainCamera = Camera.main;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            FollowMousePositionDelayed(maxSpeed);
        }
        else
        {
            RemoveForce(decreaseSpeed);
        }
        //ThrustForward(yAxis);
        //Rotate(transform, xAxis * -rotationSpeed);

    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private void RemoveForce(float decreaseSpeed)
    {
        if (rb.velocity.x >= 0f && rb.velocity.y >= 0f)
        {
            rb.velocity -= direction * decreaseSpeed;
            rb.angularVelocity = 0f;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        
    }
    private void FollowMousePositionDelayed(float maxSpeed)
    {
        //transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        direction = GetWorldPositionFromMouse() - pos;
        direction.Normalize();
        
        Debug.DrawLine(transform.position, new Vector3(GetWorldPositionFromMouse().x, GetWorldPositionFromMouse().y, 0));
        rb.AddForce(direction * maxSpeed);
    }
    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

}
