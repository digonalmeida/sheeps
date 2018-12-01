using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class SheepState : MonoBehaviour
{
    //Control Variables
    public int healthPoints;
    public float movementSpeed;
    public bool isDead {get; private set;}
    public SheepConfig config {get; private set;}

    //FSM States References
    public SheepMovementState sheepMovementState = new SheepMovementState();
    public SheepIdleState sheepIdleState = new SheepIdleState();


    public void SetupSheep(SheepConfig config)
    {
        this.config = config;
        isDead = false;
        SheepsManager.Instance.allSheeps.Add(this);
    }
}
