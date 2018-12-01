using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGrabbingOtherState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        PlayerInput.Instance.highlightTargetLocked = true;
    }

    public override void Update()
    {
        //Transitions
        if (agent.sheepAnimationController.checkEndOfAnimation("Grabbing")) agent.stateMachine.SetState(agent.sheepCapturedOtherState);
    }
}
