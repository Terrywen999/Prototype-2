using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject diamond; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("[bomb.OnTriggerEnter2D] inside if");
            Destroy(diamond.gameObject);
            
        }
    }
}
