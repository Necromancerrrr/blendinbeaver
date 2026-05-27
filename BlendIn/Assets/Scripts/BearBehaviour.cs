using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentBehaviour : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent agent;

    [HideInInspector] public bool beeCollision;
    [HideInInspector] public GameObject collidedBeehive;

    [HideInInspector] public Transform[] beehiveTransforms;
    [HideInInspector] public int lastChosenBeehive = 0;
    [HideInInspector] public Transform lastSeenPlayerPos;

    [HideInInspector] public bool playerCaught;

    [HideInInspector] public bool beehivesRecounted = false;

    public BearMaterialSwap materialSwap;
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

        CountBeehives();
        beehivesRecounted = false;

        StateMachine = new BearStateMachine();

        IdleState = new BearIdleState(this, StateMachine, "idleState", animator);

        FleeState = new BearFleeState(this, StateMachine, "fleeState", animator);

        SearchState = new BearSearchState(this, StateMachine, "searchState", animator);

        ChaseState = new BearChaseState(this, StateMachine, "chaseState", animator);

        WanderState = new BearWanderState(this, StateMachine, "wanderState", animator);

        CaughtState = new BearCaughtState(this, StateMachine, "caughtState", animator);

        StateMachine.Initialise(IdleState);
    }

    public void CountBeehives()
    {
        GameObject[] beehives = GameObject.FindGameObjectsWithTag("Beehive");
        beehiveTransforms = new Transform[beehives.Length];

        for (int i = 0; i < beehiveTransforms.Length; i++) // get all beehives
        {
            beehiveTransforms[i] = beehives[i].transform;
        }

        beehivesRecounted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) // if collided with bees
        {
            beeCollision = true;
            collidedBeehive = other.gameObject;
            Debug.Log(collidedBeehive.transform.position);
            other.gameObject.SetActive(false); // no more bees on the beehive

            CountBeehives();
        }

        if (other.gameObject.layer == 7)
        {
            playerCaught = true;
        }
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