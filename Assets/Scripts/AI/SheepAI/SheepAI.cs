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

    public GameObject SpecialTarget { get; private set; }
    
    public enum EventTriggers
    {
        WolfAppeared,
        WolfDisappeared,
        ChangeBehaviour
    }
 
    public void Awake()
    {
        
        InputData = GetComponent<SheepInputData>();
        stateMachine.Agent = this;

        idle.AddTrigger((int)EventTriggers.WolfAppeared, fleeingState);

        fleeingState.AddTrigger((int)EventTriggers.ChangeBehaviour, attackAnyone);
        fleeingState.AddTrigger((int)EventTriggers.WolfDisappeared, idle);

        attackAnyone.AddTrigger((int)EventTriggers.ChangeBehaviour, fleeingState);
        attackAnyone.AddTrigger((int)EventTriggers.WolfDisappeared, idle);
    }

    private void Start()
    {
        SpecialTarget = PlayerInput.Instance.gameObject;
        stateMachine.SetState(idle);
        StartCoroutine(StateTeste());
    }

    public void SetDebugText()
    {

    }

    private void Update()
    {
        stateMachine.Update();
    }
    
    public IEnumerator StateTeste()
    {
        stateMachine.SetState(idle);
        for (;;)
        {
            stateMachine.TriggerEvent((int)EventTriggers.WolfAppeared);
            yield return new WaitForSeconds(Random.Range(0.0f, 4.0f));
            for(int i = 0; i < 5; i++)
            {
                stateMachine.TriggerEvent((int)EventTriggers.ChangeBehaviour);
                yield return new WaitForSeconds(Random.Range(0.0f, 4.0f));
            }
            stateMachine.TriggerEvent((int)EventTriggers.WolfDisappeared);
            yield return new WaitForSeconds(Random.Range(0.0f, 4.0f));
        }
    }
}
