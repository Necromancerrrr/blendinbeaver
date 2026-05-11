using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BearIdleState : BearState
{
    public BearIdleState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    private float timer;
    private float timeInterval;

    public override void EnterState()
    {
        Debug.Log("Entered Idle");

        base.EnterState();
        timer = 0;

        timeInterval = Random.Range(2, 5); // 2 - 4 seconds of waiting doing nothing

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

        if (!bear.BlendIn.blendingIn && bear.inFOV.playerInSight) // if spotted player go to CHASE
        {
            bearStateMachine.ChangeState(bear.ChaseState);
        }

        if (timer >= timeInterval) // after x seconds go to WANDER
        {
            bearStateMachine.ChangeState(bear.WanderState);
        }
    }
}
