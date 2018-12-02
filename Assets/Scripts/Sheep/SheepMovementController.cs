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
    Vector3 KnockbackDirection = new Vector3();
    public bool flipped;

    [SerializeField]
    float MaxKnockbackForce = 1;

    [SerializeField]
    float KnockbackDeasceleration = 1;

    float _knockbackForce = 0;
    

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

    public void knockback(Vector3 direction)
    {
        KnockbackDirection = direction;
        _knockbackForce = MaxKnockbackForce;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_knockbackForce > 0)
        {
            _knockbackForce -= Mathf.Max(0, KnockbackDeasceleration * Time.deltaTime);
            charController.Move(_knockbackForce * KnockbackDirection * Time.deltaTime);
        }

        if (!CanMove)
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
        if (direction.x < 0f)
        {
            flipped = true;
            sheepAnimationController.setBool("FlippedX", true);
        }
        else if (direction.x > 0f)
        {
            flipped = false;
            sheepAnimationController.setBool("FlippedX", false);
        }

        if (charController.isGrounded)
        {
            gSpeed = Vector3.zero;
        }
    }
}
