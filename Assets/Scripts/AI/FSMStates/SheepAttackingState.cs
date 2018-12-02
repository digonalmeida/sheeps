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
    }

    public void OnAttack()
    {
        
        if (agent.checkInteractDistance())
        {
            agent.sheepInputData.targetSheep.GetComponent<SheepController>().takeDamage();
        }

        GameEvents.Sheeps.OnSheepAttack(agent.gameObject, agent.sheepInputData.targetSheep.gameObject);
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.sheepMovementController.CanMove = false;
        agent.OnAnimationFinished -= OnAttack;
    }
}
