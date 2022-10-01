using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public Animator bombAni;

    public Transform child;

    public GameObject bombImg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[bomb.OnTriggerEnter2D] outside if");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("[bomb.OnTriggerEnter2D] inside if");
            bombImg.SetActive(false);
            Destroy(collision.gameObject);
            child.gameObject.SetActive(true);
            bombAni.Play("Explosion");

            StartCoroutine(explosion(collision));


        }
    }

    IEnumerator explosion(Collider2D collision)
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
        
    }
}
