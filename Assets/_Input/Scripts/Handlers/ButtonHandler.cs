using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/* This is a scriptable object that checks for 
 * button presses that are of type bool or float
 * values that reach a certain threshold, which 
 * are interpretted as bool. 
 * 
 * This script will listen for these button presses
 * and fire an event of button down or up.
 * 
 * 
 */

[CreateAssetMenu(fileName = "NewButtonHandler")]
public class ButtonHandler : InputHandler
{
    
    public InputHelpers.Button button = InputHelpers.Button.None;

    public delegate void StateChange(XRController controller);
    public event StateChange OnButtonDown;
    public event StateChange OnButtonUp;

    // value from the previous frame. Helps keep track of when a button changes state (up/down)
    private bool previousPress = false;
    public bool IsPressed
    {
        get { return previousPress; }
    }

    public override void HandleState(XRController controller)
    {
        if(controller.inputDevice.IsPressed(button,out bool pressed,controller.axisToPressThreshold))
        {
            if(previousPress != pressed)
            {
                previousPress = pressed;

                if(pressed)
                {
                    // checks if null or not using "?"
                    OnButtonDown?.Invoke(controller);
                }
                else
                {
                    OnButtonUp?.Invoke(controller);
                }
            }
        }
    }
}