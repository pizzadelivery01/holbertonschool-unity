﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
	public bool isInverted;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		if (PlayerPrefs.GetString("Inverted") != "")
			isInverted = false;
		else
			isInverted = true;
    }

    private void LateUpdate()
    {
        CamControl();
    }
    

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * (isInverted ? -1 : 1);
        mouseY = Mathf.Clamp(mouseX, 10, 75);

        transform.LookAt(Target);
		
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
		Player.rotation = Quaternion.Euler(0, mouseX, 0);

    }
}