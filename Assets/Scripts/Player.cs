using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
	public Rigidbody rbody;
	public float speed;

	private float inputH;
	private float inputV;


	void Start ()
	{
		rbody = GetComponent<Rigidbody> ();
	}


	void Update ()
	{
		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");

		float moveX = inputH * speed * Time.deltaTime;
		float moveZ = inputV * speed * Time.deltaTime;

		rbody.velocity = new Vector3 (moveX, 0, moveZ);
	}
}
