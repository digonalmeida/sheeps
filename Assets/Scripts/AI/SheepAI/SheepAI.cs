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

        //idle.AddTrigger((int)EventTriggers.WolfAppeared, fleeingState);
        idle.AddTransition((int)EventTriggers.ChangeBehaviour, () => CurrentStrategy == Strategy.AttackAny, attackAnyone);
        idle.AddTransition((int)EventTriggers.ChangeBehaviour, () => CurrentStrategy == Strategy.AttackPlayer, attackingTarget);

      //  fleeingState.AddTrigger((int)EventTriggers.ChangeBehaviour, idle);
      //  fleeingState.AddTrigger((int)EventTriggers.WolfDisappeared, idle);

        attackAnyone.AddTrigger((int)EventTriggers.ChangeBehaviour, idle);
      //  attackAnyone.AddTrigger((int)EventTriggers.WolfDisappeared, idle);

        attackingTarget.AddTrigger((int)EventTriggers.ChangeBehaviour, idle);
      //  attackingTarget.AddTrigger((int)EventTriggers.WolfDisappeared, idle);
    }

    private void Start()
    {
       // SpecialTarget = PlayerInput.Instance.gameObject;
        stateMachine.SetState(idle);
      //  StartCoroutine(StateTeste());
    }

    public void SetIdle()
    {
        stateMachine.SetState(idle);
    }


    public void SetDebugText()
    {

    }

    public void ChangeBehaviour()
    {
        stateMachine.TriggerEvent((int)EventTriggers.ChangeBehaviour);
    }

    private void Update()
    {
        stateMachine.Update();
    }
    
    public IEnumerator StateTeste()
    {
        for (;;)
        {
            stateMachine.TriggerEvent((int)EventTriggers.ChangeBehaviour);
            yield return new WaitForSeconds(Random.Range(4.0f, 4.0f));
        }
        yield return null;
        /*
        stateMachine.SetState(idle);
        for (;;)
        {
            stateMachine.TriggerEvent((int)EventTriggers.WolfAppeared);
            yield return new WaitForSeconds(Random.Range(0.0f, 4.0f));
            for(;;)
            {
                stateMachine.TriggerEvent((int)EventTriggers.ChangeBehaviour);
                yield return new WaitForSeconds(Random.Range(0.0f, 4.0f));
            }
            stateMachine.TriggerEvent((int)EventTriggers.WolfDisappeared);
            yield return new WaitForSeconds(Random.Range(0.0f, 4.0f));
        }*/
    }
}
