using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")] [SerializeField] float xSpeed = 20;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 20;

    [SerializeField] float positionPitchFactor = - 5f;
    [SerializeField] float positionYawFactor = 6f;

    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlYawFactor = 10f;
    [SerializeField] float controlRollFactor = -20f;





    float xThrow, yThrow;

    Vector3 startingPos;


    // Use this for initialization
    void Start () {
        startingPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ProccessTranslation();
        ProccessRotation();
    }

    private void ProccessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float newX = transform.localPosition.x + xThrow * xSpeed * Time.deltaTime;
        float newY = transform.localPosition.y + yThrow * ySpeed * Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Clamp(newX, -5.8f, 5.8f), Mathf.Clamp(newY, -3.7f, 3.7f), startingPos.z);
    }

    private void ProccessRotation()
    {
        float controlPitch = 0f;
        float controlYaw = 0f;
        float controlRoll = 0f;

        if( Mathf.Abs(transform.localPosition.x - 5.8f) >= 0.01f && Mathf.Abs(transform.localPosition.x + 5.8f) >= 0.01f)
        {
            controlYaw = xThrow * controlYawFactor;
            controlRoll = xThrow * controlRollFactor;
        }
        if (Mathf.Abs(transform.localPosition.y - 3.7f) >= 0.01f && Mathf.Abs(transform.localPosition.y + 3.7f) >= 0.01f)
        {
            controlPitch = yThrow * controlPitchFactor;
        }

        float pitch = transform.localPosition.y * positionPitchFactor + controlPitch;
        float yaw = transform.localPosition.x * positionYawFactor + controlYaw;
        float roll = 0f + controlRoll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 
    }
}
