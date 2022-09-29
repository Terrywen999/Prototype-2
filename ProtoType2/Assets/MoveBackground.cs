using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float offset;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= moveSpeed * Time.deltaTime;

        if (pos.x < -offset) {
            pos.x += offset * 2;
        }

        transform.position = pos;
    }
}
