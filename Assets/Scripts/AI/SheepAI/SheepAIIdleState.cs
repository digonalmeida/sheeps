using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAIIdleState : FSMState
{
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;

        agent.InputData.movementDirection = Vector3.zero;
        agent.InputData.attacking = false;
        agent.InputData.grabThrow = false;
        agent.InputData.target = null;
        agent.InputData.moveSpeed = 0.1f;
        agent.InputData.movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
    }
    public override void OnExit()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
    }

    public override void Update()
    {
        base.OnExit();
        var agent = Agent as SheepAI;
        agent.InputData.moveSpeed = 1.0f;
    }
}
