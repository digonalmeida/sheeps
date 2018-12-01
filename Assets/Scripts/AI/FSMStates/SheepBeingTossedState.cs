using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBeingTossedState : FSMState
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
        agent.transform.position = Vector3.MoveTowards(agent.transform.position, agent.transform.position + agent.sheepInputData.movementDirection, Time.deltaTime * agent.sheepState.movementSpeed * 2f);
    }
}
