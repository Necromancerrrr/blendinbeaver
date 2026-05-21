using UnityEngine;

public class BearMaterialSwap : MonoBehaviour
{
    
    public Material chaseMat;
    public Material friendlyMat;
    public GameObject bear;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    public void SwapAngryMaterial()
    {
        skinnedMeshRenderer.material = chaseMat;
    }
    public void SwapFriendlyMaterial()
    {
        skinnedMeshRenderer.material = friendlyMat;
    }

}
