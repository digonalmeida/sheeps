using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepState))]
public class SheepAI : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();
    public SheepState sheepStateController;
    public SheepInputData sheepInputData;

    public void Awake()
    {
        stateMachine.Agent = this;
        sheepStateController = GetComponent<SheepState>();
        sheepInputData = GetComponent<SheepInputData>();
    }

    private void Start()
    {
        stateMachine.SetState(sheepStateController.sheepIdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
