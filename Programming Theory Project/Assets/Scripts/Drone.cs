using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Vehicle
{
    float heightSpeed = 2;

    [SerializeField]
    Vector3[] cameraPositionValues = new Vector3[4];
    [SerializeField]
    Vector3[] cameraRotationValues = new Vector3[4];
    enum CameraPosition
    {
        Back,
        Left,
        Front,
        Right,
    }

    CameraPosition currentCameraPosition;

    protected override void Start()
    {
        base.Start();
        currentCameraPosition = CameraPosition.Back;
        cameraOffset = new Vector3(0, 0.6f, -1f);
        cameraRotation = new Vector3(26f, 0, 0);
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.C) && isSelected)
        {
            SwitchCam();
        }
    }

    protected override void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float height = Input.GetAxis("Height");
        Vector3 verticalDirection;

        if (currentCameraPosition == CameraPosition.Left || currentCameraPosition == CameraPosition.Right)
        {
            verticalDirection = new Vector3(mainCam.transform.forward.x, 0, 0);
        }
        else
        {
            verticalDirection = new Vector3(0, 0, mainCam.transform.forward.z);
        }

        Vector3 verticalVec = verticalDirection * speed * Time.deltaTime * vertical;
        Vector3 horizontalVec = mainCam.transform.right * speed * Time.deltaTime * horizontal;

        Vector3 heightVec = mainCam.transform.up * heightSpeed * Time.deltaTime * height;

        transform.position = transform.position + verticalVec + horizontalVec + heightVec;
    }

    void SwitchCam()
    {
        currentCameraPosition += 1;

        if ((int)currentCameraPosition > 3)
        {
            currentCameraPosition = 0;
        }

        mainCam.transform.SetPositionAndRotation(transform.position + cameraPositionValues[(int)currentCameraPosition], Quaternion.Euler(cameraRotationValues[(int)currentCameraPosition]));
    }
}
