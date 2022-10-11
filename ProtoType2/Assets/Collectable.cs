using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject diamond;
    Maincanvas canvas;
    int partAmount;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        partAmount = GameObject.Find("MainCanvas").GetComponent<Maincanvas>().partAmount;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("[bomb.OnTriggerEnter2D] inside if");
            Destroy(diamond.gameObject);
            partAmount+= 1 ;
        }
        GameObject.Find("MainCanvas").GetComponent<Maincanvas>().partAmount = partAmount;
    }


}
