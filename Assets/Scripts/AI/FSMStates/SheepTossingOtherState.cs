﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepTossingOtherState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;

        if (agent.sheepInputData.movementDirection.magnitude < 1)
        {
            agent.sheepInputData.targetSheep.GetComponent<SheepController>().getTossed(agent.sheepMovementController.lastNormalizedMovement);
        }
        else
        {
            agent.sheepInputData.targetSheep.GetComponent<SheepController>().getTossed(agent.sheepInputData.movementDirection);
        }

        agent.sheepAnimationController.setTrigger("Attack");
    }
}
