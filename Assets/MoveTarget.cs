using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;
    private bool switchLerp;
    // Start is called before the first frame update
    void Start()
    {
        switchLerp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = transform.position;
        Vector3 aPos = pointA.position;
        Vector3 bPos = pointB.position;
        if(targetPos == aPos)
        {
            switchLerp = true;
        }
        else if(targetPos == bPos)
        {
            switchLerp = false;
        }

        if(!switchLerp)
        {
            transform.position = Vector3.MoveTowards(targetPos, aPos, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(targetPos, bPos, speed);
        }
    }
}
