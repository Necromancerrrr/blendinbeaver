using UnityEngine;

public class BearSearchState : BearState
{
    public BearSearchState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationState, Animator animationController) : base(bear, bearStateMachine, animationState, animationController)
    {
    }

    float transitionCheckTimer; // used to leave this state
    float movementTimer; // used to determine when to change destination

    public override void EnterState()
    {
        Debug.Log("Entered Search");

        base.EnterState();
        transitionCheckTimer = 0;
        movementTimer = 0;

        bear.growl.SetText("WHERE BEAVER", 5.0f);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        transitionCheckTimer += Time.deltaTime;
        movementTimer += Time.deltaTime;

        base.FrameUpdate();

        if (movementTimer >= 2)
        {
            Vector2 randomPos = Random.insideUnitCircle * 10;

            while (Vector2.Distance(randomPos, new Vector2(0f, 0f)) <= 2) // while the circle is within 2 of the origin randomise again
            {
                randomPos = Random.insideUnitCircle * 10;
            }
            
            bear.agent.SetDestination(bear.lastSeenPlayerPos.position + new Vector3(randomPos.x, bear.transform.position.y, randomPos.y));
            movementTimer = 0;
        }
        
        // move around last area player was spotted
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

        if (transitionCheckTimer >= 6) // if no player after x seconds go to IDLE
        {
            bearStateMachine.ChangeState(bear.IdleState);
        }

        
    }
}
