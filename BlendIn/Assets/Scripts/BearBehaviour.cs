using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviour : MonoBehaviour
{
    
    private Animator animator;
    private NavMeshAgent agent;
    
    public SwingingArmLocomotion BlendIn;
   
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (BlendIn.blendingIn == false)
        {
            //must add cone of vision
            agent.SetDestination(Camera.main.transform.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
      
    }

}