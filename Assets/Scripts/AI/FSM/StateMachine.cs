using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public FSMState CurrentState { get; private set; }
    public object Agent;
    public List<int> triggered = new List<int>();

    public void SetState(FSMState state)
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

    public void TriggerEvent(int eventType)
    {
        triggered.Add(eventType);
    }

    public void Update()
    {
        var nextState = CurrentState.CheckTransitions(triggered);
        if(nextState != null)
        {
            SetState(nextState);
        }
        triggered.Clear();
        CurrentState.Update();
    }
}