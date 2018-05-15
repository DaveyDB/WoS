using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;

    float xAxisClamp = 0;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        RotateCamera();
	}

    void RotateCamera()
    {
        if (Input.GetButton("Fire2"))
        {
            //Get Mouse position and rotation amount
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float rotAmountX = mouseX * mouseSensitivity;
            float rotAmountY = mouseY * mouseSensitivity;

            xAxisClamp -= rotAmountY;

            //Entire body should move when looking horizontally, but only camera should move when looking vertically
            Vector3 targetRotCam = transform.rotation.eulerAngles;
            Vector3 targetRotBody = playerBody.rotation.eulerAngles;

            targetRotCam.x -= rotAmountY;
            targetRotCam.z = 0;

            targetRotBody.y += rotAmountX;

            //Prevent camera from clipping when looking up and down
            if (xAxisClamp > 90)
            {
                xAxisClamp = 90;
                targetRotCam.x = 90;
            }
            else if (xAxisClamp < -90)
            {
                xAxisClamp = -90;
                targetRotCam.x = 270;
            }

            transform.rotation = Quaternion.Euler(targetRotCam);
            playerBody.rotation = Quaternion.Euler(targetRotBody);
        }
    }
}
