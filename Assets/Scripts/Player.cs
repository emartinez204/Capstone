using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Security.Cryptography;



public class Player : MonoBehaviour
{
	public Rigidbody rbody;
	//	public GameObject cam;
	//	public CharacterController controller;
	//	public float speed;
	//	public float turnSpeed;

	public Transform spot1;
	public Transform spot2;
	public Transform spot3;

	//	private float inputH;
	//	private float inputV;
	//
	//	public bool canMove;


	void Start ()
	{
		rbody = GetComponent<Rigidbody> ();
//		canMove = true;
	}


	//	void Update ()
	//	{
	//		if (GameManager.instance.usingController) {
	//			inputH = Input.GetAxis ("HorizontalJ");
	//			inputV = Input.GetAxis ("VerticalJ");
	//		} else {
	//			inputH = Input.GetAxis ("HorizontalK");
	//			inputV = Input.GetAxis ("VerticalK");
	//		}
	//
	//
	//
	//		if (canMove) {
	//			rbody.constraints = RigidbodyConstraints.None;
	//
	//
	//			Vector3 relativePos = cam.transform.TransformDirection (new Vector3 (inputH, inputV));
	//			relativePos.y = 0f;
	//			Quaternion rotation = Quaternion.LookRotation (relativePos);
	//			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * turnSpeed);
	//
	//
	//			Vector3 forward = cam.transform.TransformDirection (Vector3.forward);
	//			forward.y = 0f;
	//			forward = forward.normalized;
	//			Vector3 right = new Vector3 (forward.z, 0, -forward.x);
	//
	//
	//			Vector3 moveDirection = (inputH * right + inputV * forward) * speed * Time.deltaTime;
	//
	//			moveDirection.y = rbody.velocity.y;
	//
	//			rbody.velocity = moveDirection;
	//		}
	//
	//
	//
	//
	//
	//	}

	public void setPos (int spotNum)
	{
		rbody.constraints = RigidbodyConstraints.FreezeRotationX |
		RigidbodyConstraints.FreezeRotationY |
		RigidbodyConstraints.FreezeRotationZ |
		RigidbodyConstraints.FreezePositionX |
		RigidbodyConstraints.FreezePositionY |
		RigidbodyConstraints.FreezePositionZ;
		
		if (spotNum == 1) {
			transform.position = spot1.position;
			transform.rotation = spot1.rotation;
		} else if (spotNum == 2) {
			transform.position = spot2.position;
			transform.rotation = spot1.rotation;
		} else if (spotNum == 3) {
			transform.position = spot3.position;
			transform.rotation = spot1.rotation;
		}
	}

	public void removeConstraints ()
	{
		rbody.constraints = RigidbodyConstraints.FreezeRotationX |
		RigidbodyConstraints.FreezeRotationY |
		RigidbodyConstraints.FreezeRotationZ;
	}
}
