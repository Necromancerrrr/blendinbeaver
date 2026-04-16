
using UnityEngine;
using UnityEngine.AI;

public class TEDInteract : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public Player BlendIn;
    public FieldOfView inFOV;
    public CharacterTextBox TedDialogue;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (!BlendIn.blendingIn && inFOV.playerInSight)
        {
            TedDialogue.SetText("Hey there, I'm Ted! Got any logs?", 10.0f);

            print("TED INTERACTING"); //debug
        }

        if (BlendIn.blendingIn && inFOV.playerInSight)
        {
            TedDialogue.SetText("Did that shrub just move?", 10.0f);
        }

    }
}
