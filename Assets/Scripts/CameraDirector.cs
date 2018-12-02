using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirector : MonoBehaviour
{

    public Transform followingTransform;
    public Transform cameraMover;
    public Transform minX, maxX, minZ, maxZ;
    public float initialCenterDistance = -11.2f;
    public Animator animator;
    private float distanceMultiplier = 1f;
    public float timeStandingToOpenCamera = 2f;
    private bool isOpened = true;

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

        UpdateZoom();
    }

    private void UpdateZoom()
    {
        if (PlayerInput.Instance != null)
        {
            if (!isOpened && PlayerInput.Instance.timerNoInput > timeStandingToOpenCamera)
            {
                OpenCamera();
            }
            else if (isOpened && PlayerInput.Instance.timerNoInput < timeStandingToOpenCamera)
            {
                CloseCamera();
            }
        }
    }

    private void UpdatePosition()
    {
        Vector3 expectedPosition = new Vector3(
            Mathf.Clamp(followingTransform.position.x, distanceMultiplier * minX.position.x, distanceMultiplier * maxX.position.x),
            0,
            initialCenterDistance + Mathf.Clamp(followingTransform.position.z, distanceMultiplier * (minZ.position.z - initialCenterDistance), distanceMultiplier * (maxZ.position.z - initialCenterDistance))
        );

        cameraMover.position = Vector3.Lerp(cameraMover.position, expectedPosition, 2.5f * Time.deltaTime);
    }

    public void CloseCamera()
    {
        animator.SetBool("close", true);
        distanceMultiplier = 1f;
		isOpened = false;
    }
    public void OpenCamera()
    {
        animator.SetBool("close", false);
        distanceMultiplier = 0.1f;
		isOpened = true;
    }


}
