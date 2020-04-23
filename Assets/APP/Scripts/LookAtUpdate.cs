using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtUpdate : MonoBehaviour
{
    public Transform target;
    public Vector3 _lookAtPoint;

    void Start()
    {
        // transform.LookAt(transform.position * 2 - target.position);
        

        // Point the object at the world origin (0,0,0)
        // transform.LookAt(Vector3.zero);
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }

        if (target == null)
        {
            // Point the object at the world origin (0,0,0)
            //transform.LookAt(Vector3.zero);
            transform.LookAt(_lookAtPoint);
        }
    }
}
