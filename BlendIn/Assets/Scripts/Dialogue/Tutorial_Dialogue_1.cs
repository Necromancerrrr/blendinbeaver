
using UnityEngine;
using UnityEngine.AI;

public class TEDInteract : MonoBehaviour
{
    
    public FieldOfView inFOV;
    public CharacterTextBox TedDialogue;

    private void Start()
    {      

    }

    void Update()
    {
        if (inFOV.playerInSight)
        {
            TedDialogue.SetText("DAM nab it! I’ve fallen into this valley and hurt my back. " +
                "How am I going to build a dam now? Can you please collect some sticks for me?" +
                "Hold down the triggers on your controllers and reach down to grab them!");
        }

    }
}
