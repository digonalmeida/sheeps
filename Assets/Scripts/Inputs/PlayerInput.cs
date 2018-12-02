using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class PlayerInput : MonoBehaviour
{
    //Variables
    private SheepInputData sheepInputData;

    private static PlayerInput instance;
    public static PlayerInput Instance
    {
        get
        {
            return instance;
        }
    }

    public bool CanUse = false;
    public float timerNoInput {get; private set;}

    //On Object Awake
    private void Awake()
    {
        //Check Singleton
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    public void DisableInput(){
        sheepInputData.movementDirection = Vector3.zero;
        sheepInputData.attacking = false;
        sheepInputData.grabThrow = false;
        enabled = false;
    }

    public void EnableInput(){
        enabled = true;
    }

    //Start
    private void Start()
    {
        sheepInputData = GetComponent<SheepInputData>();

        timerNoInput = 99999f;
    }

    // Update is called once per frame
    void Update ()
    {
        if(!enabled)
        {
            sheepInputData.movementDirection = Vector3.zero;
            return;
        }

        //Movement
        sheepInputData.movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if(sheepInputData.movementDirection.sqrMagnitude <= 0.1f){
            timerNoInput+= Time.deltaTime;
        } else {
            timerNoInput = 0f;
        }


        //Action
        if (Input.GetButtonDown("Fire1")) sheepInputData.attacking = true;
        else sheepInputData.attacking = false;

        //Attack
        if (Input.GetButtonDown("Fire2")) sheepInputData.grabThrow = true;
        else sheepInputData.grabThrow = false;
    }
}
