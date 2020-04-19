using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/* SCRIPT FUNCTION:
 * Creates a list of scriptable objects.
 * Goes through the list at update.
 * Handles the input for each scriptable object.
 * 
 * USAGE:
 * Apply to XR controller Game Object in scene (Left and Right separately)
 */

public class InputManager : MonoBehaviour
{
    // List of button handler scriptable objects
    public List<ButtonHandler> allButtonHandlers = new List<ButtonHandler>();

    private XRController controller = null;

    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        HandleButtonEvents();
    }

    private void HandleButtonEvents()
    {
        foreach(ButtonHandler handler in allButtonHandlers)
        {
            handler.HandleState(controller);
        }
    }

    // vector2 values controller inputs
    private void HandleAxis2DEvents()
    {

    }

    // float values controller inputs
    public void HandleAxisEvents()
    {

    }
}

