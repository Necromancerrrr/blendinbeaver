using UnityEngine;

public class BearChaseState : BearState
{
    public BearChaseState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Entered Chase");

        base.EnterState();

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        
        bear.growl.SetText("GRRR!", 5.0f);

        bear.agent.isStopped = false;
        bear.agent.SetDestination(bear.inFOV.objectHunted.position);
        bear.animator.SetFloat("Speed", bear.agent.velocity.magnitude);

        bear.lastSeenPlayerPos = bear.inFOV.objectHunted; // get pos of last point bear as seen player

        // bear chases player
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void TransitionChecks()
    {
        base.TransitionChecks();

        if (!bear.inFOV.playerInSight) // if lose track of player go to SEARCH
        {
            bearStateMachine.ChangeState(bear.SearchState);
        }

        if (bear.BlendIn.blendingIn && bear.inFOV.playerInSight) // if player disguise go to SEARCH
        {
            bearStateMachine.ChangeState(bear.SearchState);
        }

        if (bear.playerCaught) // if player caught go to CAUGHT
        {
            bearStateMachine.ChangeState(bear.CaughtState);
        }
    }
}
