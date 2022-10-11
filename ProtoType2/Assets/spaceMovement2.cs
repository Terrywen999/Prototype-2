using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

   
    //public Transform shootPoint;
    public float recoilForce;
    public float dragValue;

    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;


    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }

    private void Shoot()
    {
        rb.drag = 0f;
        Debug.Log("[spaceMovement.Shoot]");
        Vector2 lookDir = mousePos - rb.position;
        lookDir.Normalize();
        //Instantiate(bullet, mousePos, transform.rotation);

        rb.AddForce(-lookDir * recoilForce, ForceMode2D.Impulse);
        StartCoroutine(AddDrag());

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator AddDrag() {
        yield return new WaitForEndOfFrame();
        rb.drag = dragValue;
    }
}
