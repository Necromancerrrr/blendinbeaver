using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviour : MonoBehaviour
{
    
    private Animator animator;
    private NavMeshAgent agent;
    
    public Player BlendIn;
    public FieldOfView inFOV;
   
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (!BlendIn.blendingIn && inFOV.playerInSight)
            // if the player is not blending in and is in the bear's FOV
        {
            agent.isStopped = false;
            agent.SetDestination(Camera.main.transform.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);

            // bear chases player

            print("CHASING"); //debug

        }
        
        if (BlendIn.blendingIn && inFOV.playerInSight)
            // if the player is blending in and is still in the bear's FOV
        {
            print("BEAR CAN SEE ME BLENDING IN"); //debug

            //stop at location
            agent.isStopped = true;
            print("BEAR STOPPING"); //debug 

            //wait for 2 seconds then move randomly
            //WaitForSeconds wait = new WaitForSeconds(2f);
            print("BEAR MOVING RANDOMLY"); //debug

        }

        // this can just be else but I'm trying to debug! 

        if (!BlendIn.blendingIn && !inFOV.playerInSight)
                // if the player is not blending in and is not in sight of the bear
        {
            print("BEAR CAN'T SEE ME AND IS WANDERING"); //debug

            //move randomly placeholder
            agent.isStopped = false;
   
        }


    }

  
}