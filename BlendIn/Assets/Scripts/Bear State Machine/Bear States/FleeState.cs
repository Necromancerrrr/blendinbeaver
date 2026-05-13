using UnityEngine;

public class BearFleeState : BearState
{
    public BearFleeState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationName, Animator animationController) : base(bear, bearStateMachine, animationName, animationController)
    {
    }

    float timer;
    int randPosMin;

    public override void EnterState()
    {
        Debug.Log("Entered Flee");

        base.EnterState();
        
        timer = 0;

        bear.beeCollision = false;

        randPosMin = Random.Range(0, 2) * 2 - 1;

        // Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform; use if it feels like the bear is getting too close to player

        bear.agent.SetDestination(new Vector3(bear.transform.position.x + 30 * randPosMin, bear.transform.position.y, bear.transform.position.z + 30 * randPosMin));
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

        if (timer >= 8) // after x seconds go to IDLE
        {
            bearStateMachine.ChangeState(bear.IdleState);
        }
    }
}
