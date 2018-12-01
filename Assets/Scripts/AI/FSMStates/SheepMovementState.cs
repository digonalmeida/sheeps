using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementState : FSMState
{
    //Control Variables
    private Vector3 target;
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        target = agent.transform.position;
    }

    public override void Update()
    {
        //Movement
        target = agent.transform.position + agent.sheepInputData.movementDirection;
        agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, Time.deltaTime * agent.sheepState.movementSpeed);

        //Transitions
        if (agent.sheepInputData.movementDirection == Vector3.zero) agent.stateMachine.SetState(agent.sheepIdleState);
        if (agent.sheepInputData.grabThrow && agent.sheepInputData.targetSheep != null && Vector3.Distance(agent.transform.position, agent.sheepInputData.targetSheep.transform.position) <= agent.sheepState.grabDistance) agent.stateMachine.SetState(agent.sheepGrabbingOtherState);
    }
}
