using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BearIdleState : BearState
{
    public BearIdleState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    float timer;

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
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

        if (!bear.BlendIn.blendingIn && bear.inFOV.playerInSight) // if spotted player go to CHASE
        {
            bearStateMachine.ChangeState(bear.ChaseState);
        }

        if (timer >= 3) // after x seconds go to WANDER
        {
            bearStateMachine.ChangeState(bear.WanderState);
        }
    }
}
