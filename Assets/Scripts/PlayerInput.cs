using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class PlayerInput : MonoBehaviour
{
    //Variables
    SheepInputData sheepInputData;

    //Start
    private void Start()
    {
        sheepInputData = GetComponent<SheepInputData>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Movement
        sheepInputData.movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        //Action
        if (Input.GetButton("Fire1")) sheepInputData.attacking = true;
        else sheepInputData.attacking = false;

        //Attack
        if (Input.GetButton("Fire2")) sheepInputData.grabThrow = true;
        else sheepInputData.grabThrow = false;
    }
}
