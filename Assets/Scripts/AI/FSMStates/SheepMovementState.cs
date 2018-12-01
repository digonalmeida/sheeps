using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementState : FSMState
{
    //Control Variables
    Vector3 target;

    public override void OnEnter()
    {
        base.OnEnter();
        var agent = Agent as SheepAI;
        target = agent.transform.position;
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

        //Movement
     //   target += agent.sheepInputData.movementDirection;
     //   agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, Time.deltaTime * agent.sheepStateController.movementSpeed);

        //Transitions
      //  if (agent.sheepInputData.movementDirection == Vector3.zero) agent.stateMachine.SetState(agent.sheepStateController.sheepIdleState);
    }
}
