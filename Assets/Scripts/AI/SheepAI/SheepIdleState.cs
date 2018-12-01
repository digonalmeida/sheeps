using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepIdleState : State
{
    //Control Variables
    private SheepAI agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepAI;
    }

    public override void Update()
    {
        //Transitions
        if (agent.sheepInputData.movementDirection != Vector3.zero) agent.stateMachine.SetState(agent.sheepStateController.sheepMovementState);
    }
}
