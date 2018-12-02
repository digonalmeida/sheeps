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
    private int layerMask;
    RaycastHit hitInfo;

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

        layerMask = LayerMask.GetMask("Floor");
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
        sheepInputData.movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        //Action
        if (Input.GetButtonDown("Fire1")) sheepInputData.attacking = true;
        else sheepInputData.attacking = false;

        //Attack
        if (Input.GetButtonDown("Fire2")) sheepInputData.grabThrow = true;
        else sheepInputData.grabThrow = false;

        //Update Target
        if(!highlightTargetLocked) sheepInputData.targetSheep = target;
        
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000, layerMask))
        {
            //Update Look Direction
            Vector3 vect = (hitInfo.point - this.transform.position);
            vect.y = 0;
            vect.Normalize();
            sheepInputData.lookDirection = vect;
        }
    }
}
