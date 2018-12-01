using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGrabbingOtherState : State
{
    //Control Variables
    private SheepAI agent;

    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
    }

    public override void Update()
    {
        //Transitions
        if (agent.sheepAnimationController.checkEndOfAnimation("Grabbing")) agent.stateMachine.SetState(agent.sheepStateController.sheepCapturedOtherState);
    }
}
