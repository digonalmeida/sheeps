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
        sheepInputData.movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Action
        if (Input.GetButton("Fire1"))
        {
            sheepInputData.attacking = true;
        }

        //Attack
        if (Input.GetButton("Fire2"))
        {
            sheepInputData.grabThrow = true;
        }
    }
}
