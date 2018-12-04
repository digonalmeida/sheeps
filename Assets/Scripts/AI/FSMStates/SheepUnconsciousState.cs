using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepUnconsciousState : FSMState
{
    //Control Variables
    private SheepController agent;
    private float timer;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        timer = agent.sheepAnimationController.timeAnimationUncounscious;
        agent.sheepAnimationController.setBool("Unconscious", true);
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_FallUncounscious);
        agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z - 0.5f);
        agent.lockTarget = false;
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepAnimationController.setBool("Unconscious", false);
        agent.sheepState.recover();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            agent.stateMachine.TriggerEvent((int)FSMEventTriggers.FinishedAnimation);
        }
    }
}
