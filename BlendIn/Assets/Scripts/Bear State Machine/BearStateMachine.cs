using UnityEngine;
using UnityEngine.Playables;

public class BearStateMachine
{
    public BearState CurrentState;

    public void Initialise(BearState initialState)
    {
        CurrentState = initialState;
        CurrentState.EnterState();
    }

    public void ChangeState(BearState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
        //Debug.Log("Changed state to " + CurrentState.ToString());
    }
}
