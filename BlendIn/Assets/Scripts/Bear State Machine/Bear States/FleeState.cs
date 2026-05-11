using UnityEngine;

public class BearFleeState : BearState
{
    public BearFleeState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    float timer;

    public override void EnterState()
    {
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
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void TransitionChecks()
    {
        base.TransitionChecks();

        if (timer >= 3) // after x seconds go to IDLE
        {
            bearStateMachine.ChangeState(bear.IdleState);
        }
    }
}
