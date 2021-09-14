using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    float turnSpeed = 40;

    protected override void Start()
    {
        base.Start();
        cameraOffset = new Vector3(0 , 1.2f, -1.6f);
        cameraRotation = new Vector3(26f, 0, 0);
    }

    protected override void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        if (Input.GetAxis("Vertical") < 0)
        {
            horizontal *= -1;
        }

        transform.position = transform.position + transform.right * speed * Time.deltaTime * vertical;

        if (Mathf.Abs(vertical) > 0.1)
        {
            transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
        }
    }
}
