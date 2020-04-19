using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

/* USAGE:
 * Assign as to a GameObject that should react to button presses (down/up) boolean values.
 * 
 */

public class InputListener : MonoBehaviour
{

    [Header("Buttons - SO input handlers of type:(bool)")]
    [Tooltip("Add ButtonHandler ScriptableObjects here. Any button added here will trigger the Action Down or Action Up UnityEvents.")]
    public ButtonHandler[] _buttonHandlers;

    [Space(20)]
    [Header("UnityEvents")]
    [Tooltip("Add the action you want for button up and down actions. Drag in a component and select the action from the drop-down.")]
    public UnityEvent actionDown;
    public UnityEvent actionUp;

    public void OnEnable()
    {
        // subscribe to button events
        if (_buttonHandlers.Length > 0)
        {
            for (int i = 0; i < _buttonHandlers.Length; i++)
            {
                _buttonHandlers[i].OnButtonDown += ButtonDown;
                _buttonHandlers[i].OnButtonUp += ButtonUp;

            }
        }
    }

    public void OnDisable()
    {
        // Unsubscribe from button events
        if (_buttonHandlers.Length > 0)
        {
            for (int i = 0; i < _buttonHandlers.Length; i++)
            {
                _buttonHandlers[i].OnButtonDown -= ButtonDown;
                _buttonHandlers[i].OnButtonUp -= ButtonUp;

            }
        }
    }

    private void ButtonDown(XRController controller)
    {
        print("Button down" + controller);
        actionDown.Invoke();
    }
    private void ButtonUp(XRController controller)
    {
        print("Button Up" + controller);
        actionUp.Invoke();
    }    
}
