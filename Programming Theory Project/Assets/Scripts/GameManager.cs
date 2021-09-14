using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] vehicles = new GameObject[3];
    [SerializeField]
    Vehicle currentVehicle = null;

    void Update()
    {
        ManageInput();
    }
    void ChangeVehicle(int newVehicle)
    {
        if (newVehicle >= 0)
        {
            if (currentVehicle != null)
            {
                currentVehicle.isSelected = false;
            }

            currentVehicle = vehicles[newVehicle].GetComponent<Vehicle>();
            currentVehicle.AttachCamera();
            currentVehicle.isSelected = true;
        }
    }

    void ManageInput()
    {
         int newVehicle = -1;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            newVehicle = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            newVehicle = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            newVehicle = 2;
        }
        
        if (newVehicle >= 0)
        {
            if (currentVehicle != null)
            {
                if (vehicles[newVehicle] == currentVehicle.gameObject)
                {
                    return;
                }
            }
            ChangeVehicle(newVehicle);
        }
    }
}
