using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController CharacterController;

	public float movementSpeed = 9.0f;
	public float currentMovementSpeed;
	public float maxMovementSpeedOnWalk = 9.0f;
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



	}

	private void keyboard()
	{
		float moveWS = Input.GetAxis("Vertical") * movementSpeed;
		float moveAD = Input.GetAxis("Horizontal") * movementSpeed;


		//jump
		if (CharacterController.isGrounded && Input.GetButton("Jump"))
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
		if (Input.GetKeyDown("left shift"))
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
		Camera.main.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
	}
}
