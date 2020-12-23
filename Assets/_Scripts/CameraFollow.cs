using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;


    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y > transform.position.y + 4.2f)
        {
            Vector2 newPos = new Vector2(transform.position.x, target.position.y);
            transform.position = newPos;
        }
    }
}
