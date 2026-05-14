using UnityEngine;
using UnityEngine.SceneManagement;

public class BearCaughtState : BearState
{
    public BearCaughtState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationState, Animator animationController) : base(bear, bearStateMachine, animationState, animationController)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Entered Caught");

        base.EnterState();

        // restart scene

        Debug.Log("Player is dead");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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
    }
}
