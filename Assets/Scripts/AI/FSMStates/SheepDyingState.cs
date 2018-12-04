using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDyingState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        timer = agent.sheepAnimationController.wolfFightTime;
        agent.sheepAnimationController.setTrigger("Die");
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_WolfKill);
        if (agent.transform.position.z > 0) agent.sheepAnimationController.setOrderLayer("FrontFence");
        else agent.sheepAnimationController.setOrderLayer("ForeGround");
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer <= 0f) agent.stateMachine.TriggerEvent((int)FSMEventTriggers.Death);
    }
}
