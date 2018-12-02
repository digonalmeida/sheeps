using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCapturedOtherState : FSMState
{
    //Control Variables
    private Vector3 lastPosition;
    private SheepController agent;

    public override void OnEnter()
    {
        base.OnEnter();
        agent = Agent as SheepController;
        lastPosition = agent.transform.position;
        agent.sheepInputData.targetSheep.GetComponent<SheepController>().getCaptured(agent.gameObject);
        AudioController.Instance.playSFX(AudioController.Instance.clipSFX_CaptureOther);
        agent.sheepMovementController.CanMove = true;
        agent.sheepMovementController.burdened = true;
    }

    public override void OnExit()
    {
        base.OnExit();
        agent.lockTarget = false;
        agent.sheepMovementController.CanMove = false;
        agent.sheepMovementController.burdened = false;
    }

    public override void Update()
    {
        //Movement
        if(Vector3.Distance(agent.transform.position, lastPosition) >= 0f)
        {
            //Move Carried Sheep
            agent.sheepInputData.targetSheep.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 1.5f, agent.transform.position.z);
            agent.sheepAnimationController.setBool("Walking", true);
            lastPosition = agent.transform.position;
        }
        else
        {
            agent.sheepAnimationController.setBool("Walking", false);
        }
    }
}
