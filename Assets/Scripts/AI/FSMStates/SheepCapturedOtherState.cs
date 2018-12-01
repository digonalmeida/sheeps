using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCapturedOtherState : FSMState
{
    //Control Variables
    private Vector3 target;
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepController;
        target = agent.transform.position;
    }

    public override void Update()
    {
        //Movement
        target += agent.sheepInputData.movementDirection;
        agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, Time.deltaTime * agent.sheepStateController.movementSpeed);

        //Transitions
        if (agent.sheepInputData.movementDirection == Vector3.zero) agent.stateMachine.SetState(agent.sheepStateController.sheepIdleState);
    }
}
