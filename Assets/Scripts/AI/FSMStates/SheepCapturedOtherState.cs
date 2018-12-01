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
        agent = Agent as SheepController;
        target = agent.transform.position;
        agent.sheepInputData.targetSheep.GetComponent<SheepController>().getCaptured(agent.gameObject);
    }

    public override void OnExit()
    {
        base.OnExit();
        PlayerInput.Instance.highlightTargetLocked = false;
    }

    public override void Update()
    {
        //Set Target
        target = agent.transform.position + agent.sheepInputData.movementDirection;

        //Movement
        if(Vector3.Distance(agent.transform.position, target) >= 0f)
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, Time.deltaTime * agent.sheepState.movementSpeed / 2f);
            agent.sheepInputData.targetSheep.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 0.25f, agent.transform.position.z);
            agent.sheepAnimationController.setBool("Walking", true);
        }
        else
        {
            agent.sheepAnimationController.setBool("Walking", false);
        }
    }
}
