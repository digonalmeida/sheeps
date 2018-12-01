using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAttackingTargetState : FSMState
{
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = true;
        agent.InputData.grabThrow = false;
    }

    public override void Update()
    {
        base.Update();
        var agent = Agent as SheepAI;
        var target = agent.SpecialTarget;
        if(target != null)
        {
            agent.InputData.movementDirection = (target.transform.position - agent.transform.position);
            agent.InputData.movementDirection.y = 0;
            agent.InputData.movementDirection.Normalize();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
