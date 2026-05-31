using UnityEngine;

public class BearFleeState : BearState
{
    public BearFleeState(AgentBehaviour bear, BearStateMachine bearStateMachine, string animationState, Animator animationController) : base(bear, bearStateMachine, animationState, animationController)
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

        // Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // use if it feels like the bear is getting too close to player

        bear.growl.SetText("I SCARED!!", 5.0f);

        bear.agent.SetDestination(new Vector3(-2f, bear.transform.position.y, 16.5f)); // change to fix points on map that bear runs to

        bear.agent.speed = bear.bearRunSpeed;

        bear.beesParticles.SetActive(true);
    }

    public override void ExitState()
    {
        base.ExitState();

        bear.beesParticles.SetActive(false);
    }

    public override void FrameUpdate()
    {
        timer += Time.deltaTime;

        bear.playerSpottedMeter = 0;

        TransitionChecks();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void TransitionChecks()
    {

        if (timer >= 6) // after x seconds go to IDLE
        {
            bearStateMachine.ChangeState(bear.IdleState);
        }

        if (timer > 2 && bear.agent.velocity == Vector3.zero)
        {
            bearStateMachine.ChangeState(bear.IdleState); // after bear reaches beehive go to IDLE
        }
    }
}
