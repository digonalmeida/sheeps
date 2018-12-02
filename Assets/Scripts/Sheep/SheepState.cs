﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class SheepState : MonoBehaviour
{
    //Control Variables
    private int currentHealthPoints;
    public int healthPoints = 3;
    public float movementSpeed = 1f;
    public float interactDistance = 1f;
    public float tossDistanceMultiplier = 2f;
    public float struggleTime = 1f;
    public GameObject capturor;
    public bool isDead {get; private set;}
    public SheepConfig config {get; private set;}

    public bool kill = false;

    //Initialize Variables
    private void Start()
    {
        currentHealthPoints = healthPoints;
    }

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

    public void die(){
        isDead = true;
        SheepsManager.Instance.NotificateSheepDied(this);
    }

    void Update(){
        if(kill){
            kill = false;
            die();   
        }
    }
}
