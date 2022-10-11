using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Oxygen : MonoBehaviour
{
    public float oxygenMax = 20f;
    public float oxygenLeft;
    float health = 100f;
    Image oxygenCount;

    public GameObject lose;

    bool usingOxygen;
    private void Start()
    {
        lose.SetActive(false);
        oxygenCount = GetComponent<Image>();
        oxygenLeft = oxygenMax;
        usingOxygen = true;
    }
    public void Update()
    {
        if(oxygenLeft > 0 && usingOxygen)
        {
            oxygenLeft -= 1f * Time.deltaTime;
        }
        else
        {
            lose.SetActive(true);
        }

        oxygenCount.fillAmount = oxygenLeft / oxygenMax;
    }

    public void UpdateUsingOxygen(bool val)
    {
        usingOxygen = val;
    }
}
