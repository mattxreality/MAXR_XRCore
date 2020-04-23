using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Flying : MonoBehaviour
{

    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;
    [SerializeField] float speed = 1f;
    [SerializeField] float turbo = 4f;
    [SerializeField] float rotateDampener = 0.1f;

    private InputDevice leftDevice;
    private InputDevice rightDevice;

    private Rigidbody rb;

    private float m_initialSpeed;
    private bool m_turboActivate = false;
    private bool m_turboDeActivate = true;

    public bool usingTransformForMovement;
    public bool usingRigidbodyForMovement;

    private void Start()
    {
        //LEFT HAND
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            leftDevice = leftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", leftDevice.name, leftDevice.characteristics.ToString()));
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        //RIGHT HAND
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (leftHandDevices.Count == 1)
        {
            rightDevice = rightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", rightDevice.name, rightDevice.characteristics.ToString()));
        }
        else if (rightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }

        rb = GetComponent<Rigidbody>();

        m_initialSpeed = speed;
    }


    void Update()
    {

        if (leftDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool leftGripValue) && leftGripValue
            && rightDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rightGripValue) && rightGripValue)
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
                transform.rotation = Quaternion.Euler(
                    0f,
                    leftHand.eulerAngles.y*rotateDampener, 
                    0f);
            }
        }

        //turbo activated
        if (leftDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTriggerValue) && leftTriggerValue
            && !m_turboActivate)
        {
            m_turboActivate = !m_turboActivate;
            m_turboDeActivate = !m_turboDeActivate;
            speed = speed * turbo;
        }

        //Turbo de-activated
        if (rightDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTriggerValue) && rightTriggerValue)
        {
            m_turboActivate = !m_turboActivate;
            m_turboDeActivate = !m_turboDeActivate;
            speed = m_initialSpeed; 
        }
    }
           

    private void FixedUpdate()
    {
        //uses physics force to propel player forward. Allows for inertia and drag.
        if (leftDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool leftGripValue) && leftGripValue
            && rightDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rightGripValue) && rightGripValue)
        {
            if (!usingTransformForMovement && usingRigidbodyForMovement)
            { 
                rb.AddForce(((leftHand.forward + rightHand.forward) / 2) * speed * Time.deltaTime); 
                
            }
        }
    }
}
