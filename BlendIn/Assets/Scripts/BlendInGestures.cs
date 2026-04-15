using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlendInGestures : MonoBehaviour
{
    public bool blendingIn = false;

    public InputActionReference leftGrip;
    public InputActionReference rightGrip;

    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftTrigger.action.IsPressed() && rightTrigger.action.IsPressed())
        {
            blendingIn = true;
            print("BLENDING IN");
        }
        else if (leftGrip.action.IsPressed() && rightGrip.action.IsPressed())
        {
            blendingIn = false;
        }
    }
}
