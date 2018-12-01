﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCapturedStrugglingState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        timer = agent.sheepState.struggleTime;
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            agent.stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
            agent.sheepState.capturor.GetComponent<SheepController>().stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
        }
    }
}
