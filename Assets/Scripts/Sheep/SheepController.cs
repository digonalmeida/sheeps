using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    //Controllers References
    public SheepState sheepState;
    public SheepInputData sheepInputData;
    public SheepAnimationController sheepAnimationController;

    //FSM States References
    public StateMachine stateMachine;
    public SheepIdleState sheepIdleState;
    public SheepMovementState sheepMovementState;
    public SheepGrabbingOtherState sheepGrabbingOtherState;
    public SheepCapturedOtherState sheepCapturedOtherState;
    public SheepCapturedState sheepCapturedState;
    public SheepBeingTossedState sheepBeingTossedState;
    public SheepTossingOtherState sheepTossingOtherState;

    //Start
    private void Start()
    {
        //Get Controllers
        sheepState = GetComponent<SheepState>();
        sheepInputData = GetComponent<SheepInputData>();
        sheepAnimationController = GetComponent<SheepAnimationController>();

        //FSM States
        sheepIdleState = new SheepIdleState();
        sheepMovementState = new SheepMovementState();
        sheepGrabbingOtherState = new SheepGrabbingOtherState();
        sheepCapturedOtherState = new SheepCapturedOtherState();
        sheepCapturedState = new SheepCapturedState();
        sheepBeingTossedState = new SheepBeingTossedState();
        sheepTossingOtherState = new SheepTossingOtherState();

        //Set State Machine
        stateMachine = new StateMachine();
        stateMachine.Agent = this;
        stateMachine.SetState(sheepIdleState);
    }

    public void getCaptured(GameObject capturor)
    {
        sheepState.capturor = capturor;
        stateMachine.SetState(sheepCapturedState);
    }

    public void getTossed(Vector3 direction)
    {
        sheepInputData.movementDirection = direction;
        stateMachine.SetState(sheepBeingTossedState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
