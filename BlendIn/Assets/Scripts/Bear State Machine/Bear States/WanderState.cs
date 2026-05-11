using UnityEngine;

public class BearWanderState : BearState
{
    public BearWanderState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Entered Wander");

        base.EnterState();

        bear.agent.isStopped = true; // TEMPORARY, REMOVE WHEN LOGIC IS PUT IN
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
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
    }
}
