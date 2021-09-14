using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    public float speed;
    public bool isSelected = false;
    protected Vector3 cameraOffset;
    protected Vector3 cameraRotation;
    protected GameObject mainCam;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isSelected)
        {
            Move();
        }
    }
    protected abstract void Move();

    public void AttachCamera()
    {
        mainCam.transform.SetParent(transform);
        mainCam.transform.SetPositionAndRotation(transform.position + cameraOffset, Quaternion.Euler(cameraRotation));
    }
}
