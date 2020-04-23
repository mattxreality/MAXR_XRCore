using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTumble : MonoBehaviour
{
    public float tumble = 1f;
    public bool activateTumble = false;
    private bool isTumbling = false;
    private void Update()
    {
        if(activateTumble)
        {
            if(!isTumbling)
            {
                GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
                isTumbling = true;
            }
        }
        else
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            isTumbling = false;
        }
    }

    // use these to activate via a controller input
    public void ActivateTumbling()
    {
        activateTumble = true;
    }

    public void DeactivateTumbling()
    {
        activateTumble = false;
    }

}
