using UnityEngine;

public class BearMaterialSwap : MonoBehaviour
{
    
    public Material chaseMat;
    public GameObject bear;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    public void SwapMaterial()
    {
        skinnedMeshRenderer.material = chaseMat;
    }

}
