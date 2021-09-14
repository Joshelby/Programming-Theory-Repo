using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Vehicle
{
    [SerializeField]
    float rollSpeed = 10;
    [SerializeField]
    float pitchSpeed = 10;

    [SerializeField]
    float throttle;
    float lowerThrottleBound = 5;
    float upperThrottleBound = 20;
    float acceleration = 4f;

    [SerializeField]
    GameObject propeller;
    float propellerBaseSpeed = 1;

    protected override void Start()
    {
        base.Start();
        throttle = lowerThrottleBound;
        cameraOffset = new Vector3(0, 2f, -3.5f);
        cameraRotation = new Vector3(28f, 0, 0);
    }

    protected override void Move()
    {
        UpdatePitchAndRoll();
        UpdateThrottle();
        SpinPropeller();
        Vector3 heightVec = -transform.right * throttle * Time.deltaTime;

        transform.position = transform.position + heightVec;
    }

    void UpdateThrottle()
    {
        float height = -Input.GetAxis("Height");
        throttle += acceleration * height * Time.deltaTime;
        throttle = Mathf.Clamp(throttle, lowerThrottleBound, upperThrottleBound);
    }

    /*void UpdatePitchAndRoll()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float roll = transform.rotation.z + (vertical * rollSpeed * Time.deltaTime);
        float pitch = transform.rotation.x + (horizontal * pitchSpeed * Time.deltaTime);

        transform.rotation = Quaternion.(pitch, 0, roll);
    }*/

    void UpdatePitchAndRoll()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float deltaRoll = vertical * rollSpeed * Time.deltaTime;
        float deltaPitch = horizontal * pitchSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(deltaPitch, 0, deltaRoll), Space.Self);
    }

    void SpinPropeller()
    {
        propeller.transform.Rotate(transform.forward * throttle * propellerBaseSpeed);
    }
}
