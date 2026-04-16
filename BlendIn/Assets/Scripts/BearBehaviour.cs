using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviour : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    bool blendingIn;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (blendingIn == false)
        {
            agent.SetDestination(Camera.main.transform.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
      
    }

}