
using UnityEngine;
using UnityEngine.AI;

public class TEDInstructions : MonoBehaviour
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
            TedDialogue.SetText("Hey there, I'm Ted! Can you please bring me those logs?", 10.0f);

            print("TED INTERACTING"); //debug
        }

        if (BlendIn.blendingIn && inFOV.playerInSight)
        {
            TedDialogue.SetText("Did that shrub just move?", 10.0f);
        }

    }
}
