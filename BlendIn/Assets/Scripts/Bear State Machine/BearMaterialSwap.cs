using UnityEngine;

public class BearMaterialSwap : MonoBehaviour
{
    
    public Material chaseMat;
    public GameObject bear;

    void Start()
    {
        bear.GetComponent<Renderer>().material = chaseMat;
    }

}
