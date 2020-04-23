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

    [Header("Axis 1D type:(float)")]
    public AxisHandler triggerHandlerL = null;
    public AxisHandler triggerHandlerR = null;
    public AxisHandler gripHandlerL = null;
    public AxisHandler gripHandlerR = null;

    [Header("Axis 2D type:(vector2)")]
    public AxisHandler2D primaryAxisHandlerL = null;
    public AxisHandler2D primaryAxisHandlerR = null;


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

        primaryAxisHandlerL.OnValueChange += PrintPrimaryAxisL;
        triggerHandlerL.OnValueChange += PrintTriggerL;
        gripHandlerL.OnValueChange += PrintGripL;
        primaryAxisHandlerR.OnValueChange += PrintPrimaryAxisR;
        triggerHandlerR.OnValueChange += PrintTriggerR;
        gripHandlerR.OnValueChange += PrintGripR;
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

        primaryAxisHandlerL.OnValueChange -= PrintPrimaryAxisL;
        triggerHandlerL.OnValueChange -= PrintTriggerL;
        gripHandlerL.OnValueChange -= PrintGripL;
        primaryAxisHandlerR.OnValueChange -= PrintPrimaryAxisR;
        triggerHandlerR.OnValueChange -= PrintTriggerR;
        gripHandlerR.OnValueChange -= PrintGripR;
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
        print("GripButtonL down" + controller);
    }        
    private void GripButtonUpL(XRController controller)
    {
        print("GripButtonL Up" + controller);
    }    
 
    private void GripButtonDownR(XRController controller)
    {
        print("GripButtonR down" + controller);
    }
    private void GripButtonUpR(XRController controller)
    {
        print("GripButtonR Up" + controller);
    }

    private void TriggerButtonDownL(XRController controller)
    {
        print("TriggerButtonL down" + controller);
    }
    private void TriggerButtonUpL(XRController controller)
    {
        print("TriggerButtonL Up" + controller);
    }

    private void TriggerButtonDownR(XRController controller)
    {
        print("TriggerButtonR down" + controller);
    }    
    private void TriggerButtonUpR(XRController controller)
    {
        print("TriggerButtonR Up" + controller);
    }

    private void PrimaryButtonDownL(XRController controller)
    {
        print("PrimaryButtonL down" + controller);
    }       
    private void PrimaryButtonUpL(XRController controller)
    {
        print("PrimaryButtonL Up" + controller);
    }    

    private void PrimaryButtonDownR(XRController controller)
    {
        print("PrimaryButtonR down" + controller);
    }    
    private void PrimaryButtonUpR(XRController controller)
    {
        print("PrimaryButtonR Up" + controller);
    }

    private void SecondaryButtonDownL(XRController controller)
    {
        print("SecondaryButtonL down" + controller);
    }       
    private void SecondaryButtonUpL(XRController controller)
    {
        print("SecondaryButtonL Up" + controller);
    }    

    private void SecondaryButtonDownR(XRController controller)
    {
        print("SecondaryButtonR down" + controller);
    }    
    private void SecondaryButtonUpR(XRController controller)
    {
        print("SecondaryButtonR Up" + controller);
    }

    private void MenuButtonDownL(XRController controller)
    {
        print("MenuButtonL down" + controller);
    }      
    private void MenuButtonUpL(XRController controller)
    {
        print("MenuButtonL Up" + controller);
    }    

    private void MenuButtonDownR(XRController controller)
    {
        print("MenuButtonR down" + controller);
    }    
    private void MenuButtonUpR(XRController controller)
    {
        print("MenuButtonR Up" + controller);
    }
    #endregion

    #region VECTOR2 INPUT (bool)
    private void PrintPrimaryAxisL(XRController controller, Vector2 value)
    {
        print("Primary axisL: " + value);
    }

    private void PrintPrimaryAxisR(XRController controller, Vector2 value)
    {
        print("Primary axisR: " + value);
    }
    #endregion

    #region FLOAT INPUT (bool)
    private void PrintTriggerL(XRController controller, float value)
    {
        if (value > Mathf.Epsilon)
        { print("TriggerL: " + value); }
    }

    private void PrintGripL(XRController controller, float value)
    {
        if (value > Mathf.Epsilon)
        { print("GripL: " + value); }
    }

    private void PrintTriggerR(XRController controller, float value)
    {
        // trying to get this to only register with positive values...
        if (value > 0.0001f)
        { print("TriggerR: " + value); }
    }
    private void PrintGripR(XRController controller, float value)
    {
        if (value > Mathf.Epsilon)
        { print("GripR: " + value); }
    }
    #endregion
}
