using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SheepInputData))]
public class PlayerInput : MonoBehaviour
{
    //Variables
    private SheepInputData sheepInputData;
    public GameObject target;
    public bool highlightTargetLocked;

    private static PlayerInput instance;
    public static PlayerInput Instance
    {
        get
        {
            return instance;
        }
    }

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
        highlightTargetLocked = false;
        sheepInputData = GetComponent<SheepInputData>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Movement
        sheepInputData.movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        //Action
        if (Input.GetButtonDown("Fire1")) sheepInputData.attacking = true;
        else sheepInputData.attacking = false;

        //Attack
        if (Input.GetButtonDown("Fire2")) sheepInputData.grabThrow = true;
        else sheepInputData.grabThrow = false;

        //Update Target
        if(!highlightTargetLocked) sheepInputData.targetSheep = target;

        //Update Look Direction
        Vector3 vect = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        sheepInputData.lookDirection = new Vector3(vect.x, vect.y, 0f).normalized;
    }
}
