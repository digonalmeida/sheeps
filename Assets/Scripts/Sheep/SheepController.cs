using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    //Controllers References
    public SheepState sheepStateController;
    public SheepInputData sheepInputData;
    public SheepAnimationController sheepAnimationController;

    //FSM States References
    public StateMachine stateMachine;
    public SheepIdleState sheepIdleState;
    public SheepMovementState sheepMovementState;
    public SheepGrabbingOtherState sheepGrabbingOtherState;
    public SheepCapturedOtherState sheepCapturedOtherState;

    //Start
    private void Start()
    {
        //Get Controllers
        sheepStateController = GetComponent<SheepState>();
        sheepInputData = GetComponent<SheepInputData>();
        sheepAnimationController = GetComponent<SheepAnimationController>();

        //Set State Machine
        stateMachine = new StateMachine();
        stateMachine.Agent = this;

        //FSM States
        sheepIdleState = new SheepIdleState();
        sheepMovementState = new SheepMovementState();
        sheepGrabbingOtherState = new SheepGrabbingOtherState();
        sheepCapturedOtherState = new SheepCapturedOtherState();
    }
}
