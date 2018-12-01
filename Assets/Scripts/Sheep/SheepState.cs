using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class SheepState : MonoBehaviour
{
    //Control Variables
    public int healthPoints;
    private int currentHealthPoints;
    public float movementSpeed;
    public float interactDistance;
    public float tossDistanceMultiplier;
    public float struggleTime;
    public GameObject capturor;
    public bool isDead {get; private set;}
    public SheepConfig config {get; private set;}

    public void SetupSheep(SheepConfig config)
    {
        this.config = config;
        isDead = false;
    }

    public void takeDamage()
    {
        currentHealthPoints--;
    }

    public bool checkUncounscious()
    {
        if (currentHealthPoints <= 0) return true;
        else return false;
    }

    public void recover()
    {
        currentHealthPoints = healthPoints;
    }
}
