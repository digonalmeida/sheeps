﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBeingTossedState : FSMState
{
    //Control Variables
    private Vector3 target;
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        target = agent.transform.position + (agent.sheepInputData.movementDirection * agent.sheepState.tossDistanceMultiplier);
        agent.sheepAnimationController.setBool("BeingTossed", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepAnimationController.setBool("BeingTossed", false);
    }

    public override void Update()
    {
        if (Vector3.Distance(agent.transform.position, target) <= 0.1f) agent.stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
        else agent.transform.position = Vector3.MoveTowards(agent.transform.position, agent.transform.position + agent.sheepInputData.movementDirection, Time.deltaTime * agent.sheepState.movementSpeed * 2f);
    }
}