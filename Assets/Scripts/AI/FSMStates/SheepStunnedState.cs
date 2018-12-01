using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepStunnedState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        if (agent.sheepInputData.targetSheep != null && agent.sheepInputData.targetSheep.GetComponent<SheepController>().sheepState.capturor != null) agent.sheepInputData.targetSheep.GetComponent<SheepController>().breakFreeFromCapture();
        timer = agent.sheepAnimationController.timeAnimationStunned;
    }

    public override void Update()
    {
        if (timer <= 0f) agent.stateMachine.TriggerEvent((int)FSMEventTriggers.FinishedAnimation);
    }
}
