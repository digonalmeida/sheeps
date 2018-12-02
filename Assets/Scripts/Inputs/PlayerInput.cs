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

    public float timerNoInput {get; private set;}

    //On Object Awake
    private void Awake()
    {
        //Check Singleton
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
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
