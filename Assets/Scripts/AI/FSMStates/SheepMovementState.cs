﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementState : FSMState
{
    //Control Variables
    private Vector3 target;
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        target = agent.transform.position;
    }

    public override void Update()
    {
        target = agent.transform.position + agent.sheepInputData.movementDirection;
        if (Vector3.Distance(agent.transform.position, target) >= 0f)
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, Time.deltaTime * agent.sheepState.movementSpeed);
            agent.sheepAnimationController.setBool("Walking", true);
        }
        else agent.sheepAnimationController.setBool("Walking", false);
    }
}
