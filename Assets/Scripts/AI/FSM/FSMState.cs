using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState
{
    public object Agent;
    public List<FSMStateTransition> Transitions = new List<FSMStateTransition>();

    public virtual void OnEnter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void OnExit()
    {

    }

    public FSMState CheckTransitions(List<int> triggers)
    {
        foreach(var transition in Transitions)
        {
            if(transition.Trigger != -1)
            {
                if(!triggers.Contains(transition.Trigger))
                {
                    continue;
                }
            }

            if(transition.Condition != null)
            {
                if(!transition.Condition())
                {
                    continue;
                }
            }

            return transition.TargetState;
        }
        return null;
    }

    public void AddTrigger(int eventTrigger, FSMState targetState)
    {
        AddTransition(eventTrigger, null, targetState);
    }

    public void AddCondition(Func<bool> condition, FSMState targetState)
    {
        AddTransition(-1, condition, targetState);
    }

    public void AddTransition(int eventTrigger, Func<bool> condition, FSMState targetState)
    {
        var transition = new FSMStateTransition();
        transition.Trigger = eventTrigger;
        transition.Condition = condition;
        transition.TargetState = targetState;
        Transitions.Add(transition);
    }
}