using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRRigFlying : MonoBehaviour
{

    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;
    [SerializeField] float speed = 1f;
    [SerializeField] float turbo = 4f;
    [SerializeField] float rotateDampener = 0.1f;

    public bool usingTransformForMovement = true;
    public bool usingRigidbodyForMovement = false;

    private Rigidbody rb;

    private float m_initialSpeed;
    private bool m_turboActivate = false;
    // private bool m_turboDeActivate = true;

    private bool m_isFlying = false;

    private void Start()
    {
        m_initialSpeed = speed;
    }

    public void ActivateFlying()
    {
        if (!m_isFlying)
        {
            m_isFlying = true;
        }
    }

    public void DeactivateFlying()
    {
        if (m_isFlying)
        {
            m_isFlying = false;
        }
    }

    // set this on button press DOWN
    // it will toggle
    public void ActivateTurbo()
    {
        // toggle bool
        m_turboActivate = !m_turboActivate;

        //turbo active
        if (m_turboActivate)
        {
            m_turboActivate = true;
            //m_turboDeActivate = false;
            speed = speed * turbo;
        }

        //Turbo inactivate
        if (!m_turboActivate)
        {
            m_turboActivate = false;
            //m_turboDeActivate = true;
            speed = m_initialSpeed;
        }
    }


    void Update()
    {

        if (m_isFlying)
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log("Both Grip Buttons Pressed!");
            }

            // moves forward on transform. Has no effect on physics
            if (usingTransformForMovement && !usingRigidbodyForMovement)
            {
                transform.position += ((leftHand.forward + rightHand.forward) / 2) * speed * Time.deltaTime;

                //this may blow everything up!!!!!!
                // try more options using Euler and Quaternion. Something's going to work. 
                //transform.rotation = Quaternion.Euler(
                //    0f,
                //    leftHand.eulerAngles.y*rotateDampener, 
                //    0f);
            }
        }

    }



    private void FixedUpdate()
    {
        //uses physics force to propel player forward. Allows for inertia and drag.
        if (m_isFlying)
        {
            if (!usingTransformForMovement && usingRigidbodyForMovement)
            { 
                rb.AddForce(((leftHand.forward + rightHand.forward) / 2) * speed * Time.deltaTime); 
                
            }
        }
    }
}
