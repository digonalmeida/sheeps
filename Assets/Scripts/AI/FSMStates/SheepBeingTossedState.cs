using System.Collections;
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
        target = agent.transform.position + (agent.TossDirection * agent.sheepState.tossDistanceMultiplier);
        target.y = 0f;
        agent.sheepAnimationController.setBool("BeingTossed", true);
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_YellToss);
        agent.sheepAnimationController.spriteRenderer.sortingLayerName = "ForeGround";
        agent.sheepAnimationController.particleSystemRenderer.sortingLayerName = "ForeGround";
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepAnimationController.setBool("BeingTossed", false);
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_TossLanding);
        agent.sheepAnimationController.spriteRenderer.sortingLayerName = "Default";
        agent.sheepAnimationController.particleSystemRenderer.sortingLayerName = "Default";
    }

    public override void Update()
    {
        if (Vector3.Distance(agent.transform.position, target) <= 0.1f)
        {
            agent.stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
        }
        else
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, Time.deltaTime * agent.sheepState.tossSpeedMultiplier);
        }
    }
}
