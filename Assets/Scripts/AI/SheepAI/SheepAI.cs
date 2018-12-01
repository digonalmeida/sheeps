using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepStateController))]
public class SheepAI : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();
    public SheepStateController sheepStateController;
    public SheepInputData sheepInputData;

    public void Awake()
    {
        stateMachine.Agent = this;
        sheepStateController = GetComponent<SheepStateController>();
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
