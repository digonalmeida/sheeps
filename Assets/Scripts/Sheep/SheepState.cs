using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class SheepState : MonoBehaviour
{
    //Control Variables
    public int healthPoints;
    public float movementSpeed;
    public float grabDistance;
    public GameObject capturor;
    public bool isDead {get; private set;}
    public SheepConfig config {get; private set;}

    public void SetupSheep(SheepConfig config)
    {
        this.config = config;
        isDead = false;
    }
}
