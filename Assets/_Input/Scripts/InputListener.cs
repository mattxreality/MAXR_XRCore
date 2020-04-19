using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;


//public class HandActions
//{
//    public HandActions() { }

//    public UnityEvent actionDown;
//    public UnityEvent actionPressed;
//    public UnityEvent actionUp;
//}
public class InputListener : MonoBehaviour
{

    [Header("Buttons type:(bool)")]
    public ButtonHandler triggerButtonHandlerL = null;
    public ButtonHandler triggerButtonHandlerR = null;

    public UnityEvent actionDown;
    public UnityEvent actionUp;


    public void OnEnable()
    {
        // subscribe to button down event
        triggerButtonHandlerL.OnButtonDown += TriggerButtonDownL;
        triggerButtonHandlerL.OnButtonUp += TriggerButtonUpL;
        triggerButtonHandlerR.OnButtonDown += TriggerButtonDownR;
        triggerButtonHandlerR.OnButtonUp += TriggerButtonUpR;
    }

    public void OnDisable()
    {
        // subscribe to button down event
        triggerButtonHandlerL.OnButtonDown -= TriggerButtonDownL;
        triggerButtonHandlerL.OnButtonUp -= TriggerButtonUpL;
        triggerButtonHandlerR.OnButtonDown -= TriggerButtonDownR;
        triggerButtonHandlerR.OnButtonUp -= TriggerButtonUpR;
    }

    private void TriggerButtonDownL(XRController controller)
    {
        print("TriggerButton down" + controller);
        actionDown.Invoke();
    }
    private void TriggerButtonUpL(XRController controller)
    {
        print("TriggerButton Up" + controller);
        actionUp.Invoke();
    }

    private void TriggerButtonDownR(XRController controller)
    {
        print("TriggerButton down" + controller);
        actionDown.Invoke();
    }
    private void TriggerButtonUpR(XRController controller)
    {
        print("TriggerButton Up" + controller);
        actionUp.Invoke();
    }
}
