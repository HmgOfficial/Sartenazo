using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class Control : MonoBehaviour
{
    public TextMeshProUGUI speedTXT;
    public TextMeshProUGUI accelerationTXT;

    private Quaternion localRotation;

    // The initials orientation
    private float initialOrientationX;
    private float initialOrientationY;
    private float initialOrientationZ;

    // Start is called before the first frame update
    void Start()
    {
        localRotation = transform.rotation;
        if (!Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
            initialOrientationX = Input.gyro.rotationRateUnbiased.x;
            initialOrientationY = Input.gyro.rotationRateUnbiased.y;
            initialOrientationZ = -Input.gyro.rotationRateUnbiased.z;
        }
        else if (Input.gyro.enabled)
        {
            initialOrientationX = Input.gyro.rotationRateUnbiased.x;
            initialOrientationY = Input.gyro.rotationRateUnbiased.y;
            initialOrientationZ = -Input.gyro.rotationRateUnbiased.z;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        localRotation.x = (initialOrientationX - Input.gyro.rotationRateUnbiased.x);
        localRotation.y = (initialOrientationZ - Input.gyro.rotationRateUnbiased.z);
        localRotation.z = (initialOrientationY - Input.gyro.rotationRateUnbiased.y);

        transform.Rotate(localRotation.x, localRotation.y, localRotation.z);
        //transform.EulerAngles = localRotation;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public void CheckAcceleration()
    {
        accelerationTXT.text = "EN X " + Input.gyro.attitude.x + "" +
            "EN Y " + Input.gyro.attitude.y + "" +
            "EN Z " + Input.gyro.attitude.z; 
    }
}
