using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementController : MonoBehaviour
{
    public bool CanMove = false;
    CharacterController charController;
    SheepInputData sheepInputData;
    SpriteRenderer spriteRenderer;
    SheepAnimationController sheepAnimationController;
    SheepState sheepState;
    Vector3 gSpeed = new Vector3();
    public Vector3 lastNormalizedMovement;
    public bool burdened;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
        sheepInputData = GetComponent<SheepInputData>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        sheepAnimationController = GetComponent<SheepAnimationController>();
        sheepState = GetComponent<SheepState>();
    }

    public void knockback(Vector3 attackerPos)
    {
        charController.Move((this.transform.position - attackerPos).normalized * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!CanMove)
        {
            return;
        }

        Vector3 direction = sheepInputData.movementDirection;
        direction.y = 0;
        direction.Normalize();
        gSpeed += Time.deltaTime * Physics.gravity;
        charController.Move((gSpeed * Time.deltaTime) + (direction * Time.deltaTime * sheepInputData.moveSpeed * sheepState.movementSpeed));
        if (direction.magnitude == 1) lastNormalizedMovement = direction;

        //Flip Sprite
        if (direction.x < 0f) sheepAnimationController.setBool("FlippedX", true);
        else if(direction.x > 0f) sheepAnimationController.setBool("FlippedX", false);

        if (charController.isGrounded)
        {
            gSpeed = Vector3.zero;
        }
    }
}
