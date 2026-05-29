using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BearIdleState : BearState
{
    public BearIdleState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationState, Animator animationController) : base(bear, bearStateMachine, animationState, animationController)
    {
    }

    private float timer;
    private float timeInterval;

    public override void EnterState()
    {
        Debug.Log("Entered Idle");

        base.EnterState();
        timer = 0;

        timeInterval = Random.Range(2, 4); // 0 - 1 seconds of waiting doing nothing

        bear.agent.isStopped = true; // do nothing

        bear.materialSwap.SwapFriendlyMaterial();

        bear.animator.SetFloat("Speed", 0);

        bear.agent.speed = bear.bearWalkSpeed;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        timer += Time.deltaTime;

        base.FrameUpdate();

        bear.growl.SetText("I STAND", 5.0f);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void TransitionChecks()
    {
        base.TransitionChecks();

        if (bear.playerSpottedMeter >= bear.playerSpottedMeterMax) // if spotted player go to CHASE
        {
            bearStateMachine.ChangeState(bear.ChaseState);
        }

        if (timer >= timeInterval) // after x seconds go to WANDER
        {
            bearStateMachine.ChangeState(bear.WanderState);
        }
    }
}
