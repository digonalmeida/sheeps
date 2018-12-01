using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDyingState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        timer = agent.sheepAnimationController.timeAnimationDying;
        agent.sheepAnimationController.setTrigger("Die");
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) agent.stateMachine.TriggerEvent((int)FSMEventTriggers.Death);
    }
}
