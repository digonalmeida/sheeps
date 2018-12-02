using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SheepState))]
public class SheepAI : MonoBehaviour
{

    [SerializeField]
    private Text DebugUiText;

    public SheepInputData InputData { get; private set; }

    private StateMachine stateMachine = new StateMachine();
    private SheepAIIdleState idle = new SheepAIIdleState();
    private SheepAIAttackingTargetState attackingTarget = new SheepAIAttackingTargetState();
    private SheepAIFleeingState fleeingState = new SheepAIFleeingState();
    private SheepAIAttackingAnyoneState attackAnyone = new SheepAIAttackingAnyoneState();
    private SheepAIGrabbingState grabbing = new SheepAIGrabbingState();

    public GameObject Target { get; set; }

    public GameObject SpecialTarget { get; set; }
    
    public enum Strategy
    {
        Idle,
        AttackAny,
        AttackPlayer
    }

    [SerializeField]
    private Strategy _currentStrategy = Strategy.Idle;

    public Strategy CurrentStrategy
    {
        get
        {
            return _currentStrategy;
        }
        set
        {
            _currentStrategy = value;
            stateMachine.TriggerEvent((int)EventTriggers.ChangeBehaviour);
        }
    }

    public enum EventTriggers
    {
        WolfAppeared,
        WolfDisappeared,
        ChangeBehaviour
    }
 
    public void Awake()
    {
        CurrentStrategy = Strategy.Idle;

        InputData = GetComponent<SheepInputData>();
        stateMachine.Agent = this;
    }

    private void Start()
    {
        stateMachine.SetState(idle);
    }

    public void SetAttacking()
    {
        stateMachine.SetState(attackingTarget);
    }

    public void SetIdle()
    {
        stateMachine.SetState(idle);
    }

    public void SetDebugText()
    {

    }

    public void SetRevenge(GameObject target)
    {
        Target = target;
        stateMachine.SetState(attackingTarget);
    }
    public void ChangeBehaviour()
    {
        stateMachine.TriggerEvent((int)EventTriggers.ChangeBehaviour);
    }

    private void Update()
    {
        stateMachine.Update();
    }
    
}
