using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")] [SerializeField] float xSpeed = 10;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 10;

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

    private void ProccessRotation()
    {
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProccessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float newX = transform.localPosition.x + xThrow * xSpeed * Time.deltaTime;
        float newY = transform.localPosition.y + yThrow * ySpeed * Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Clamp(newX, -5.8f, 5.8f), Mathf.Clamp(newY, -3.2f, 3.2f), startingPos.z);
    }
}
