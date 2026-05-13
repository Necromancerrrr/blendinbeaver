using UnityEngine;

public class BearState
{
    protected AgentBehaviour bear;
    protected BearStateMachine bearStateMachine;
    protected Animator animationController;
    protected string animationName;

    protected bool isExitingState;
    protected bool isAnimationFinished;
    protected float startTime;

    public BearState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController)
    {
        this.bear = bear;
        this.bearStateMachine = bearStateMachine;
        this.animationController = animationController;
        this.animationName = animationName;
    }

    public virtual void EnterState()
    {
        isAnimationFinished = false;
        isExitingState = false;
        startTime = Time.time;
        //animationController.SetBool(animationName, true);

        bear.playerCaught = false;
    }

    public virtual void ExitState()
    {
        isExitingState = true;
        //if (!isAnimationFinished) isAnimationFinished = true;
        //animationController.SetBool(animationName, false);
    }

    public virtual void FrameUpdate()
    {
        TransitionChecks();
    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void TransitionChecks()
    {
        //isAnimationFinished = true;

        if (bear.beeCollision)  // if beehive nearby FLEE
        {
            bearStateMachine.ChangeState(bear.FleeState);
        }
    }
}
