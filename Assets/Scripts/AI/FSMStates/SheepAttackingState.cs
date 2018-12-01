using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAttackingState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        timer = agent.sheepAnimationController.timeAnimationAttacking;
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (agent.checkInteractDistance()) agent.sheepInputData.targetSheep.GetComponent<SheepController>().takeDamage();
            agent.stateMachine.TriggerEvent((int)FSMEventTriggers.FinishedAnimation);
        }
    }
}
