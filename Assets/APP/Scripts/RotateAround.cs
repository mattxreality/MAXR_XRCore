using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    [SerializeField] float m_rate = 30f;
    [SerializeField] Transform m_target;
    
    private Vector3 target;

    void Update()
    {
        target = m_target.transform.position;

        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(target, Vector3.up, m_rate * Time.deltaTime);
    }
}
