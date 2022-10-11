using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private Rigidbody2D rig2d;
    public Transform player;
    private void Start()
    {
        rig2d = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rig2d.rotation = angle;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            Shoot();
        }
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
