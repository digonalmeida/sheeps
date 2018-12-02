using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAttackingState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        agent.sheepAnimationController.setTrigger("Attack");
        agent.sheepMovementController.CanMove = true;
        agent.OnAnimationFinished += OnAttack;
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_Punch);
    }

    public void OnAttack()
    {
        if (agent.checkInteractDistance()) agent.sheepInputData.targetSheep.GetComponent<SheepController>().takeDamage();
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepMovementController.CanMove = false;
        agent.OnAnimationFinished -= OnAttack;
    }
}
