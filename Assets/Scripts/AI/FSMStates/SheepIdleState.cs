using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepIdleState : FSMState
{
    //Control Variables
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
    }

    public override void Update()
    {
        //Transitions
        if (agent.sheepInputData.movementDirection != Vector3.zero) agent.stateMachine.SetState(agent.sheepMovementState);
        if (agent.sheepInputData.grabThrow && agent.sheepInputData.targetSheep != null && Vector3.Distance(agent.transform.position, agent.sheepInputData.targetSheep.transform.position) <= agent.sheepState.grabDistance) agent.stateMachine.SetState(agent.sheepGrabbingOtherState);
    }
}
