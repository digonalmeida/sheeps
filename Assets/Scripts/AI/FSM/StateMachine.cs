using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }
    public object Agent;

    public void SetState(State state)
    {
        if(CurrentState != null)
        {
            CurrentState.OnExit();
        }

        CurrentState = state;

        if(CurrentState != null)
        {
            CurrentState.Agent = Agent;
            CurrentState.OnEnter();
        }
    }

    public void Update()
    {
        CurrentState.Update();
    }
}