using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGrabbingOtherState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        PlayerInput.Instance.highlightTargetLocked = true;
        timer = agent.sheepAnimationController.timeAnimationGrabbing;
        agent.sheepAnimationController.setTrigger("Attack");
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) agent.stateMachine.TriggerEvent((int)FSMEventTriggers.FinishedAnimation);
    }
}
