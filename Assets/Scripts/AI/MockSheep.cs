using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockSheep : MonoBehaviour {
    CharacterController charController;
    SheepInputData sheepInputData;
    SpriteRenderer spriteRenderer;
    float speed = 2;
    Vector3 gSpeed = new Vector3();
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        sheepInputData = GetComponent<SheepInputData>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {
        Vector3 direction = sheepInputData.movementDirection;
        direction.y = 0;
        direction.Normalize();
        gSpeed += Time.deltaTime * Physics.gravity;
        charController.Move((gSpeed * Time.deltaTime) + (direction * Time.deltaTime * sheepInputData.moveSpeed * speed));
        if(charController.isGrounded)
        {
            gSpeed = Vector3.zero;
        }

        if(sheepInputData.grabThrow)
        {
            spriteRenderer.color = Color.red;
        }
        else if(sheepInputData.attacking)
        {
            spriteRenderer.color = Color.magenta;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
	}
}
