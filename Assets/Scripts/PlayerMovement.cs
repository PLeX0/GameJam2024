using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{

	public CharacterController CharacterController;

	public Camera mainCamera;
	public GameObject cameraPoint;
	public GameObject cameraCrouchPoint;
	public float movementSpeed = 9.0f;
	public float maxMovementSpeedOnWalk = 9.0f;
	public float maxMovementSpeedOnWalk2 = 9.0f;
	public float maxMovementSpeedOnCrouch = 4.5f;
	public float jumpHeight = 7.0f;
	public float jumpHeightNow = 0f;
	public float sprintSpeed = 7.0f;
	public float sensivity = 3.0f;
	public float mouseUpDown = 0.0f;
	public float upDownLimit = 90.0f;
	public float fasterFalling = 0f;
	public bool isSprint;
	public bool isJump;
	public bool isInspecting = false;
	public bool isMoveingItem = false;
	public bool isCrouch = false;
	// Use this for initialization
	void Start()
	{
		isSprint = false;
		CharacterController = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isSprint == false)
			movementSpeed = maxMovementSpeedOnWalk;

        if (isInspecting == false)
        {
            mouse();
		    keyboard();
        }
		else if(isInspecting == true && isMoveingItem==true)
        {
			mouse();
			keyboard();
		}
		

		if(isCrouch)
        {
			if(CharacterController.isGrounded)
			maxMovementSpeedOnWalk = maxMovementSpeedOnCrouch;

			mainCamera.transform.position = cameraCrouchPoint.transform.position;
		}
		else if(!isCrouch)
        {
			maxMovementSpeedOnWalk = maxMovementSpeedOnWalk2;
			mainCamera.transform.position = cameraPoint.transform.position;
		}

	}

	private void keyboard()
	{
		float moveWS = Input.GetAxis("Vertical") * movementSpeed;
		float moveAD = Input.GetAxis("Horizontal") * movementSpeed;

        ////crouch
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isSprint)
        {
			isCrouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
			isCrouch = false;
        }

		//zoom
		if(Input.GetKey(KeyCode.Z) && isInspecting==false)
        {
			mainCamera.fieldOfView = 20f;			
		}
		else if(Input.GetKeyUp(KeyCode.Z))
        {
			mainCamera.fieldOfView = 60f;
		}

        //jump
        if (CharacterController.isGrounded && Input.GetButton("Jump") && !isCrouch)
		{
			jumpHeightNow = jumpHeight;
			isJump = true;
		}
		else if (!CharacterController.isGrounded)
		{
			jumpHeightNow += Physics.gravity.y * (Time.deltaTime + fasterFalling);
			isJump = false;
		}


		//sprint
		if (Input.GetKeyDown("left shift") && !isCrouch)
		{
			movementSpeed += sprintSpeed;
			isSprint = true;
		}
		else if (Input.GetKeyUp("left shift"))
		{
			movementSpeed -= sprintSpeed;
			isSprint = false;
		}


		Vector3 move = new Vector3(moveAD, jumpHeightNow, moveWS);
		move = transform.rotation * move;

		CharacterController.Move(move * Time.deltaTime);

	}

	private void mouse()
	{
		float mouseLeftRight = Input.GetAxis("Mouse X") * sensivity;
		transform.Rotate(0, mouseLeftRight, 0);

		mouseUpDown -= Input.GetAxis("Mouse Y") * sensivity;
		mouseUpDown = Mathf.Clamp(mouseUpDown, -upDownLimit, upDownLimit);
		mainCamera.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
	}
}
