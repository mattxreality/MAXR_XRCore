using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleListener : MonoBehaviour
{
    [Header("Buttons type:(bool)")]
    public ButtonHandler primaryAxisClickHandlerL = null;
    public ButtonHandler primaryAxisClickHandlerR = null;
    public ButtonHandler triggerButtonHandlerL = null;
    public ButtonHandler triggerButtonHandlerR = null;
    public ButtonHandler gripButtonHandlerL = null;
    public ButtonHandler gripButtonHandlerR = null;
    public ButtonHandler primaryButtonHandlerL = null;
    public ButtonHandler primaryButtonHandlerR = null;
    public ButtonHandler secondaryButtonHandlerL = null;
    public ButtonHandler secondaryButtonHandlerR = null;
    public ButtonHandler menuButtonHandlerL = null;
    public ButtonHandler menuButtonHandlerR = null;

    public void OnEnable()
    {
        // subscribe to button down event
        primaryAxisClickHandlerL.OnButtonDown += PrintPrimaryButtonDownL;
        primaryAxisClickHandlerL.OnButtonUp += PrintPrimaryButtonUpL;
        primaryAxisClickHandlerR.OnButtonDown += PrintPrimaryButtonDownR;
        primaryAxisClickHandlerR.OnButtonUp += PrintPrimaryButtonUpR;
        gripButtonHandlerL.OnButtonDown += GripButtonDownL;        
        gripButtonHandlerL.OnButtonUp += GripButtonUpL;        
        gripButtonHandlerR.OnButtonDown += GripButtonDownR;        
        gripButtonHandlerR.OnButtonUp += GripButtonUpR;
        triggerButtonHandlerL.OnButtonDown += TriggerButtonDownL;        
        triggerButtonHandlerL.OnButtonUp += TriggerButtonUpL;        
        triggerButtonHandlerR.OnButtonDown += TriggerButtonDownR;        
        triggerButtonHandlerR.OnButtonUp += TriggerButtonUpR;
        primaryButtonHandlerL.OnButtonDown += PrimaryButtonDownL;        
        primaryButtonHandlerL.OnButtonUp += PrimaryButtonUpL;        
        primaryButtonHandlerR.OnButtonDown += PrimaryButtonDownR;        
        primaryButtonHandlerR.OnButtonUp += PrimaryButtonUpR;
        secondaryButtonHandlerL.OnButtonDown += SecondaryButtonDownL;        
        secondaryButtonHandlerL.OnButtonUp += SecondaryButtonUpL;        
        secondaryButtonHandlerR.OnButtonDown += SecondaryButtonDownR;        
        secondaryButtonHandlerR.OnButtonUp += SecondaryButtonUpR;
        menuButtonHandlerL.OnButtonDown += MenuButtonDownL;         
        menuButtonHandlerL.OnButtonUp += MenuButtonUpL;        
        menuButtonHandlerR.OnButtonDown += MenuButtonDownR;        
        menuButtonHandlerR.OnButtonUp += MenuButtonUpR;
    }

    public void OnDisable()
    {
        // UNsubscribe to button down event
        primaryAxisClickHandlerL.OnButtonDown -= PrintPrimaryButtonDownL;
        primaryAxisClickHandlerL.OnButtonUp -= PrintPrimaryButtonUpL;
        primaryAxisClickHandlerR.OnButtonDown -= PrintPrimaryButtonDownR;
        primaryAxisClickHandlerR.OnButtonUp -= PrintPrimaryButtonUpR;
        gripButtonHandlerL.OnButtonDown -= GripButtonDownL;
        gripButtonHandlerL.OnButtonUp -= GripButtonUpL;
        gripButtonHandlerR.OnButtonDown -= GripButtonDownR;
        gripButtonHandlerR.OnButtonUp -= GripButtonUpR;
        triggerButtonHandlerL.OnButtonDown -= TriggerButtonDownL;
        triggerButtonHandlerL.OnButtonUp -= TriggerButtonUpL;
        triggerButtonHandlerR.OnButtonDown -= TriggerButtonDownR;
        triggerButtonHandlerR.OnButtonUp -= TriggerButtonUpR;
        primaryButtonHandlerL.OnButtonDown -= PrimaryButtonDownL;
        primaryButtonHandlerL.OnButtonUp -= PrimaryButtonUpL;
        primaryButtonHandlerR.OnButtonDown -= PrimaryButtonDownR;
        primaryButtonHandlerR.OnButtonUp -= PrimaryButtonUpR;
        secondaryButtonHandlerL.OnButtonDown -= SecondaryButtonDownL;
        secondaryButtonHandlerL.OnButtonUp -= SecondaryButtonUpL;
        secondaryButtonHandlerR.OnButtonDown -= SecondaryButtonDownR;
        secondaryButtonHandlerR.OnButtonUp -= SecondaryButtonUpR;
        menuButtonHandlerL.OnButtonDown -= MenuButtonDownL;
        menuButtonHandlerL.OnButtonUp -= MenuButtonUpL;
        menuButtonHandlerR.OnButtonDown -= MenuButtonDownR;
        menuButtonHandlerR.OnButtonUp -= MenuButtonUpR;
    }
    #region BUTTON INPUT (bool)
    private void PrintPrimaryButtonDownL(XRController controller)
    {
        print("Left primary button down" + controller);
    }
    private void PrintPrimaryButtonUpL(XRController controller)
    {
        print("Left primary button Up" + controller);
    }
    private void PrintPrimaryButtonDownR(XRController controller)
    {
        print("Right primary button down" + controller);
    }
    private void PrintPrimaryButtonUpR(XRController controller)
    {
        print("Right primary button Up" + controller);
    }

    private void GripButtonDownL(XRController controller)
    {
        print("GripButton down" + controller);
    }        
    private void GripButtonUpL(XRController controller)
    {
        print("GripButton Up" + controller);
    }    
 
    private void GripButtonDownR(XRController controller)
    {
        print("GripButton down" + controller);
    }
    private void GripButtonUpR(XRController controller)
    {
        print("GripButton Up" + controller);
    }

    private void TriggerButtonDownL(XRController controller)
    {
        print("TriggerButton down" + controller);
    }
    private void TriggerButtonUpL(XRController controller)
    {
        print("TriggerButton Up" + controller);
    }

    private void TriggerButtonDownR(XRController controller)
    {
        print("TriggerButton down" + controller);
    }    
    private void TriggerButtonUpR(XRController controller)
    {
        print("TriggerButton Up" + controller);
    }

    private void PrimaryButtonDownL(XRController controller)
    {
        print("PrimaryButton down" + controller);
    }       
    private void PrimaryButtonUpL(XRController controller)
    {
        print("PrimaryButton Up" + controller);
    }    

    private void PrimaryButtonDownR(XRController controller)
    {
        print("PrimaryButton down" + controller);
    }    
    private void PrimaryButtonUpR(XRController controller)
    {
        print("PrimaryButton Up" + controller);
    }

    private void SecondaryButtonDownL(XRController controller)
    {
        print("SecondaryButton down" + controller);
    }       
    private void SecondaryButtonUpL(XRController controller)
    {
        print("SecondaryButton Up" + controller);
    }    

    private void SecondaryButtonDownR(XRController controller)
    {
        print("SecondaryButton down" + controller);
    }    
    private void SecondaryButtonUpR(XRController controller)
    {
        print("SecondaryButton Up" + controller);
    }

    private void MenuButtonDownL(XRController controller)
    {
        print("MenuButton down" + controller);
    }      
    private void MenuButtonUpL(XRController controller)
    {
        print("MenuButton Up" + controller);
    }    

    private void MenuButtonDownR(XRController controller)
    {
        print("MenuButton down" + controller);
    }    
    private void MenuButtonUpR(XRController controller)
    {
        print("MenuButton Up" + controller);
    }
    #endregion


    private void PrintPrimaryAxis(XRController controller, Vector2 value)
    {

    }

    private void PrintTrigger(XRController controller, float value)
    {

    }
}
