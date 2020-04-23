using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        // transform.LookAt(transform.position * 2 - target.position);
        transform.LookAt(target);

        // Point the object at the world origin (0,0,0)
        // transform.LookAt(Vector3.zero);
    }

    void Update()
    {
        
    }
}
