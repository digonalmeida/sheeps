using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepIdleState : State
{
    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
    }

    public override void OnExit()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
    }

    public override void Update()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;

        //Transitions
        if (agent.sheepInputData.movementDirection != Vector3.zero) agent.stateMachine.SetState(agent.sheepStateController.sheepMovementState);
    }
}
