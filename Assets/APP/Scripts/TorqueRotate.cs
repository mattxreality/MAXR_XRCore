using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueRotate : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float amount = 100f;

    [SerializeField] bool right_x = false; // x
    [SerializeField] bool up_y = true; // y
    [SerializeField] bool forward_z = false; // z



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Rotate()
    {
        if (up_y)
        {
            rb.AddTorque(transform.up * amount);
        }
        if (forward_z)
        {
            rb.AddTorque(transform.forward * amount);
        }
        if (right_x)
        {
            rb.AddTorque(transform.right * amount);
        }


    }
}
