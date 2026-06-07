using UnityEngine;
using UnityEngine.UI;

public class BlendInTutorial : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RawImage image;

    [SerializeField] private Texture2D angryBear;
    [SerializeField] private Texture2D happyBear;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.blendingIn)
        {
            image.texture = happyBear;
        }
        else
        {
            image.texture = angryBear;
        }
    }
}
