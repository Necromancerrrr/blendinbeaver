using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadTracking : MonoBehaviour
{

    public FieldOfView inFOV; 
    public MultiAimConstraint headAim; 
    public RigBuilder rig; 
  
   
    void Update()
    {
        if (inFOV.playerInSight == true)
        {
            headAim.weight = 0.5f;

    
        }
        else
        {
            headAim.weight = 0f;

           
        }
    }
}
