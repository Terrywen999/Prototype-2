using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private Rigidbody2D rig;

    void Awake() {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            Debug.Log("[Floating.OnTriggerEnter2D]");
            Destroy(this.gameObject);
        }
    }
}