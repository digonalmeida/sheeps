﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeadState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        agent.sheepAnimationController.setTrigger("Die");
        agent.sheepState.die();
        agent.sheepAnimationController.setSortingOrder(-2);
    }
}
