using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepStunnedState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        if (agent.sheepInputData.targetSheep != null && agent.sheepInputData.targetSheep.GetComponent<SheepController>().sheepState.capturor != null) agent.sheepInputData.targetSheep.GetComponent<SheepController>().breakFreeFromCapture();
    }

    public override void Update()
    {
        if (agent.sheepAnimationController.checkEndOfAnimation("Stun")) agent.stateMachine.TriggerEvent((int)FSMEventTriggers.FinishedAnimation);
    }
}
