using UnityEngine;

public class BearSearchState : BearState
{
    public BearSearchState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    float timer;

    public override void EnterState()
    {
        Debug.Log("Entered Search");

        base.EnterState();
        timer = 0;

        bear.agent.isStopped = true; // TEMPORARY, REMOVE WHEN LOGIC IS PUT IN
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        timer += Time.deltaTime;


        base.FrameUpdate();

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

        if (timer >= 3) // if no player after x seconds go to IDLE
        {
            bearStateMachine.ChangeState(bear.IdleState);
        }

        
    }
}
