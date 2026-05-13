using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviour : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent agent;

    [HideInInspector] public bool beeCollision;
    [HideInInspector] public Transform[] beehiveTransforms = new Transform[7];
    [HideInInspector] public int lastChosenBeehive = 0;
    [HideInInspector] public Transform lastSeenPlayerPos;

    [HideInInspector] public bool playerCaught;

    public Player BlendIn;
    public FieldOfView inFOV;
    public CharacterTextBox growl;

    #region State Machine Vars

    public BearStateMachine StateMachine;

    public BearIdleState IdleState;

    public BearFleeState FleeState;

    public BearSearchState SearchState;

    public BearChaseState ChaseState;

    public BearWanderState WanderState;

    public BearCaughtState CaughtState;

    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        GameObject[] beehives = GameObject.FindGameObjectsWithTag("Beehive");
        
        for (int i = 0; i < beehiveTransforms.Length; i++) // get all beehives
        {
            print(beehives[i].transform.position);
            beehiveTransforms[i] = beehives[i].transform;
        }
        
        StateMachine = new BearStateMachine();

        IdleState = new BearIdleState(this, StateMachine, null, null);

        FleeState = new BearFleeState(this, StateMachine, null, null);

        SearchState = new BearSearchState(this, StateMachine, null, null);

        ChaseState = new BearChaseState(this, StateMachine, null, null);

        WanderState = new BearWanderState(this, StateMachine, null, null);

        CaughtState = new BearCaughtState(this, StateMachine, null, null);

        StateMachine.Initialise(IdleState);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) // if collided with beehive
        {
            beeCollision = true;

            other.gameObject.SetActive(false); // no more bees on the beehive
        }

        if (other.gameObject.layer == 7)
        {
            playerCaught = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
        /*
        if (inFOV.isBeehive && inFOV.playerInSight)
        {
            growl.SetText("GRRR!", 5.0f);

            agent.isStopped = false;
            agent.SetDestination(inFOV.objectHunted.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);

            // bear chases player

            print("CHASING BEE"); //debug
            
        }
        

        if (!BlendIn.blendingIn && inFOV.playerInSight)
            // if the player is not blending in and is in the bear's FOV
        {
            growl.SetText("GRRR!", 5.0f);

            agent.isStopped = false;
            agent.SetDestination(inFOV.objectHunted.position);
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
        */

    }


}