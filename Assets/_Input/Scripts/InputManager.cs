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
    public List<AxisHandler2D> allAxisHandlers2D = new List<AxisHandler2D>();
    public List<AxisHandler> allAxisHandlers = new List<AxisHandler>();

    private XRController controller = null;

    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        HandleButtonEvents();
        HandleAxis2DEvents();
        HandleAxisEvents();
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
        foreach (AxisHandler2D handler in allAxisHandlers2D)
        { 
            handler.HandleState(controller); 
        }
    }

    // float values controller inputs
    public void HandleAxisEvents()
    {
        foreach (AxisHandler handler in allAxisHandlers)
        { 
            handler.HandleState(controller); 
        }
    }
}

