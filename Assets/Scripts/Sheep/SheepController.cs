using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FSMEventTriggers
{
    Death,
    Unconscious,
    FinishedAnimation,
    Tossed,
    Stun,
    Captured
}

public class SheepController : MonoBehaviour
{
    //Controllers References
    public SheepState sheepState;
    public SheepInputData sheepInputData;
    public SheepAnimationController sheepAnimationController;

    //FSM States References
    public StateMachine stateMachine;
    public SheepDyingState sheepDyingState;
    public SheepIdleState sheepIdleState;
    public SheepMovementState sheepMovementState;
    public SheepGrabbingOtherState sheepGrabbingOtherState;
    public SheepCapturedOtherState sheepCapturedOtherState;
    public SheepCapturedUnconsciousState sheepCapturedUnconsciousState;
    public SheepCapturedStrugglingState sheepCapturedStrugglingState;
    public SheepBeingTossedState sheepBeingTossedState;
    public SheepTossingOtherState sheepTossingOtherState;
    public SheepAttackingState sheepAttackingState;
    public SheepStunnedState sheepStunnedState;
    public SheepUnconsciousState sheepUnconsciousState;

    //Start
    private void Start()
    {
        //Get Controllers
        sheepState = GetComponent<SheepState>();
        sheepInputData = GetComponent<SheepInputData>();
        sheepAnimationController = GetComponent<SheepAnimationController>();

        //FSM States
        sheepDyingState = new SheepDyingState();
        sheepIdleState = new SheepIdleState();
        sheepMovementState = new SheepMovementState();
        sheepGrabbingOtherState = new SheepGrabbingOtherState();
        sheepCapturedOtherState = new SheepCapturedOtherState();
        sheepCapturedUnconsciousState = new SheepCapturedUnconsciousState();
        sheepCapturedStrugglingState = new SheepCapturedStrugglingState();
        sheepBeingTossedState = new SheepBeingTossedState();
        sheepTossingOtherState = new SheepTossingOtherState();
        sheepAttackingState = new SheepAttackingState();
        sheepStunnedState = new SheepStunnedState();
        sheepUnconsciousState = new SheepUnconsciousState();

        //FSM Transitions
        sheepIdleState.AddTransition((int)FSMEventTriggers.Captured, sheepState.checkUncounscious, sheepCapturedUnconsciousState);
        sheepIdleState.AddTransition((int)FSMEventTriggers.Captured, () => !sheepState.checkUncounscious(), sheepCapturedStrugglingState);
        sheepIdleState.AddTrigger((int)FSMEventTriggers.Unconscious, sheepUnconsciousState);
        sheepIdleState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);
        sheepIdleState.AddCondition(() => sheepInputData.grabThrow && checkInteractDistance(), sheepGrabbingOtherState);
        sheepIdleState.AddCondition(() => sheepInputData.attacking, sheepAttackingState);
        sheepIdleState.AddCondition(() => sheepInputData.movementDirection != Vector3.zero, sheepMovementState);

        sheepMovementState.AddTransition((int)FSMEventTriggers.Captured, sheepState.checkUncounscious, sheepCapturedUnconsciousState);
        sheepMovementState.AddTransition((int)FSMEventTriggers.Captured, () => !sheepState.checkUncounscious(), sheepCapturedStrugglingState);
        sheepMovementState.AddTrigger((int)FSMEventTriggers.Unconscious, sheepUnconsciousState);
        sheepMovementState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);
        sheepMovementState.AddCondition(() => sheepInputData.grabThrow && checkInteractDistance(), sheepGrabbingOtherState);
        sheepMovementState.AddCondition(() => sheepInputData.attacking, sheepAttackingState);
        sheepMovementState.AddCondition(() => sheepInputData.movementDirection == Vector3.zero, sheepMovementState);

        sheepGrabbingOtherState.AddTrigger((int)FSMEventTriggers.Unconscious, sheepUnconsciousState);
        sheepGrabbingOtherState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);
        sheepGrabbingOtherState.AddTransition((int)FSMEventTriggers.FinishedAnimation, checkInteractDistance, sheepCapturedOtherState);
        sheepGrabbingOtherState.AddTransition((int)FSMEventTriggers.FinishedAnimation, () => !checkInteractDistance(), sheepIdleState);

        sheepCapturedOtherState.AddTrigger((int)FSMEventTriggers.Unconscious, sheepUnconsciousState);
        sheepCapturedOtherState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);
        sheepCapturedOtherState.AddCondition(() => sheepInputData.grabThrow, sheepTossingOtherState);

        sheepCapturedUnconsciousState.AddTrigger((int)FSMEventTriggers.Tossed, sheepBeingTossedState);
        sheepCapturedStrugglingState.AddTrigger((int)FSMEventTriggers.Tossed, sheepBeingTossedState);
        sheepCapturedStrugglingState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);

        sheepBeingTossedState.AddTrigger((int)FSMEventTriggers.Death, sheepDyingState);
        sheepBeingTossedState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);

        sheepTossingOtherState.AddCondition(() => true, sheepIdleState);

        sheepAttackingState.AddTransition((int)FSMEventTriggers.Captured, sheepState.checkUncounscious, sheepCapturedUnconsciousState);
        sheepAttackingState.AddTransition((int)FSMEventTriggers.Captured, () => !sheepState.checkUncounscious(), sheepCapturedStrugglingState);
        sheepAttackingState.AddTrigger((int)FSMEventTriggers.Unconscious, sheepUnconsciousState);
        sheepAttackingState.AddTrigger((int)FSMEventTriggers.Stun, sheepStunnedState);
        sheepAttackingState.AddTrigger((int)FSMEventTriggers.FinishedAnimation, sheepIdleState);

        sheepStunnedState.AddTransition((int)FSMEventTriggers.Captured, sheepState.checkUncounscious, sheepCapturedUnconsciousState);
        sheepStunnedState.AddTransition((int)FSMEventTriggers.Captured, () => !sheepState.checkUncounscious(), sheepCapturedStrugglingState);
        sheepStunnedState.AddTrigger((int)FSMEventTriggers.Unconscious, sheepUnconsciousState);
        sheepStunnedState.AddTrigger((int)FSMEventTriggers.FinishedAnimation, sheepIdleState);

        sheepUnconsciousState.AddTrigger((int)FSMEventTriggers.Captured, sheepCapturedUnconsciousState);
        sheepUnconsciousState.AddTrigger((int)FSMEventTriggers.FinishedAnimation, sheepIdleState);

        //Set State Machine
        stateMachine = new StateMachine();
        stateMachine.Agent = this;
        stateMachine.SetState(sheepIdleState);
    }

    //Update
    private void Update()
    {
        stateMachine.Update();
    }

    //Sheep Controller Aux Methods
    public void takeDamage()
    {
        Debug.LogWarning("DAMAGE");
        sheepState.takeDamage();
        if (sheepState.checkUncounscious()) stateMachine.TriggerEvent((int)FSMEventTriggers.Unconscious);
    }

    public void getCaptured(GameObject capturor)
    {
        sheepState.capturor = capturor;
        stateMachine.TriggerEvent((int)FSMEventTriggers.Captured);
    }

    public void breakFreeFromCapture()
    {
        sheepState.capturor = null;
        stateMachine.TriggerEvent((int)FSMEventTriggers.Stun);
    }

    public void getTossed(Vector3 direction)
    {
        sheepInputData.movementDirection = direction;
        stateMachine.TriggerEvent((int)FSMEventTriggers.Tossed);
    }

    public bool checkInteractDistance()
    {
        return sheepInputData.targetSheep != null && Vector3.Distance(transform.position, sheepInputData.targetSheep.transform.position) <= sheepState.interactDistance;
    }
}
