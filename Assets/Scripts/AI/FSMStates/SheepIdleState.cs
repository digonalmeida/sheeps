﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepIdleState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
    }

    public override void Update()
    {
        //Transitions
        if (agent.sheepInputData.movementDirection != Vector3.zero) agent.stateMachine.SetState(agent.sheepMovementState);
    }
}