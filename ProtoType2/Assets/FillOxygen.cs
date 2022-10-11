using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillOxygen : MonoBehaviour
{
    public GameObject oxygen;
    public float oxygenLeft;
    public float addingSpeed;
    float oxygenMax;
    bool isAdding = false;
    private void Start()
    {
        
        oxygenMax = oxygen.GetComponent<Oxygen>().oxygenMax ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        oxygenLeft = oxygen.GetComponent<Oxygen>().oxygenLeft;
        Debug.Log($"Stay {oxygenLeft}");
        if (collision.gameObject.name.Equals("Player") && oxygenLeft < 20)
        {
            Debug.Log("hhh");
            isAdding = true;
        }
        oxygen.GetComponent<Oxygen>().UpdateUsingOxygen(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        oxygenLeft = oxygen.GetComponent<Oxygen>().oxygenLeft;

        if (collision.gameObject.name.Equals("Player") && oxygenLeft < 20)
        {
            Debug.Log("hhh");
            isAdding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            isAdding = false;
        oxygen.GetComponent<Oxygen>().UpdateUsingOxygen(true);
    }
   
    private void Update()
    {
        if (oxygenLeft < oxygenMax && isAdding)
        {
            oxygenLeft += addingSpeed * Time.deltaTime;
            Debug.Log($"Update {oxygenLeft}");
            oxygen.GetComponent<Oxygen>().oxygenLeft = oxygenLeft;
        }
        
    }


}
