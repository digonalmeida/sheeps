using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepState))]
public class SheepAI : MonoBehaviour
{

    public SheepInputData InputData { get; private set; }

    private StateMachine stateMachine = new StateMachine();
    private SheepIdleState idle = new SheepIdleState();
    private SheepAttackingTargetState attackingTarget = new SheepAttackingTargetState();
    private SheepFleeingState fleeingState = new SheepFleeingState();
    private SheepAttackingAnyoneState attackAnyone = new SheepAttackingAnyoneState();
    private SheepAiGrabbingState grabbing = new SheepAiGrabbingState();

    public GameObject SpecialTarget { get; private set; }
 
    public void Awake()
    {
        SpecialTarget = GameObject.Find("mocktarget");
        InputData = GetComponent<SheepInputData>();
        stateMachine.Agent = this;
    }

    private void Start()
    {
        stateMachine.SetState(attackingTarget);
        StartCoroutine(StateTeste());
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public IEnumerator StateTeste()
    {
        for(;;)
        {
            stateMachine.SetState(idle);
            yield return new WaitForSeconds(1);
            stateMachine.SetState(attackingTarget);
            yield return new WaitForSeconds(1);
            stateMachine.SetState(fleeingState);
            yield return new WaitForSeconds(1);
            stateMachine.SetState(attackAnyone);
            yield return new WaitForSeconds(1);
            stateMachine.SetState(grabbing);
            yield return new WaitForSeconds(1);
        }
    }
}
