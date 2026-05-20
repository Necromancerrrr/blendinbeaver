using UnityEngine;

public class BearWanderState : BearState
{
    public BearWanderState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationState, Animator animationController) : base(bear, bearStateMachine, animationState, animationController)
    {
    }

    private Transform destination = null;
    private float movementTimer;
    private float timeIntervals;

    public override void EnterState()
    {
        Debug.Log("Entered Wander");

        base.EnterState();

        bear.agent.isStopped = false;

        movementTimer = 0;

        timeIntervals = Random.Range(8, 11); // choose how long the bear will be moving towards this target, 8 - 10 seconds range

        int randNum = Random.Range(0, 7); // choose a random beehive to travel to

        while (randNum == bear.lastChosenBeehive) // stops same beehive being chosen twice in a row
        {
            randNum = Random.Range(0, 7);
        }

        bear.lastChosenBeehive = randNum;

        destination = bear.beehiveTransforms[randNum];

        // Debug.Log(destination);

        bear.growl.SetText("I WANDER", 5.0f);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        movementTimer += Time.deltaTime;

        

        bear.agent.SetDestination(destination.position);
        bear.animator.SetFloat("Speed", bear.agent.velocity.magnitude);

        

        base.FrameUpdate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void TransitionChecks()
    {
        base.TransitionChecks();

        if (!bear.BlendIn.blendingIn && bear.inFOV.playerInSight) // if spotted player go to CHASE
        {
            bearStateMachine.ChangeState(bear.ChaseState);
        }

        if (movementTimer > timeIntervals)
        {
            //bearStateMachine.ChangeState(bear.IdleState); // after x seconds go to IDLE
        }

        if (movementTimer > 1 && bear.agent.velocity == Vector3.zero)
        {
            bearStateMachine.ChangeState(bear.IdleState); // after bear reaches beehive go to IDLE
        }
    }
}
