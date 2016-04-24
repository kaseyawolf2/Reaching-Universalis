﻿using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]
public class Player : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	float verticalRotation = 0;
	float upDownRange = 60.0f;
	public static Vector3 Currenttrans;
	float verticalVelocity = 0;

	//Jumping
	public int JumpHeight = 5;


	CharacterController characterController;
	
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();

	

		if (Camera.main == null) {
			print ("No camera");
		}
	}
	
	// Update is called once per frame
	void Update () {
		 
		if(Statics.ShowMouse == true){
			Cursor.visible = true;
		}else{
			Cursor.visible = false;
		}




		// Rotation
		if(Statics.ShowMouse == false){
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);
		
		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		}
		
		// Movement
		
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

		//Jumping
		if (characterController.isGrounded == false) {
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		} else {
			verticalVelocity = Physics.gravity.y/4;
			if(Input.GetKeyDown(KeyCode.Space)){
				verticalVelocity = JumpHeight;
			}
		}

		Vector3 speed = new Vector3( sideSpeed, verticalVelocity, forwardSpeed );
		
		speed = transform.rotation * speed;
		
		
		characterController.Move( speed * Time.deltaTime );
	}
}