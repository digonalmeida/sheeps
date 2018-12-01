using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class SheepStateController : MonoBehaviour
{
    //Control Variables
    public int healthPoints;
    public float movementSpeed;

    //FSM States References
    public SheepMovementState sheepMovementState = new SheepMovementState();
    public SheepIdleState sheepIdleState = new SheepIdleState();
}
