﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCapturedStrugglingState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;
    public bool bleat;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        timer = agent.sheepAnimationController.struggleTime;
        agent.sheepAnimationController.setBool("Struggling", true);
        bleat = false;
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepAnimationController.setBool("Struggling", false);
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if(timer <= 0.5f && !bleat)
        {
            bleat = true;
            AudioController.Instance.playSFX(AudioController.Instance.clipSFX_BleatNeutral);
        }
        else if (timer <= 0f)
        {
            agent.stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
            agent.sheepState.capturor.GetComponent<SheepController>().stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
        }
    }
}
