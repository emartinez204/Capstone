using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pitchfork : MonoBehaviour
{
	bool holding = false;

	private Transform grabber;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (holding) {
//			Vector3 pos = new Vector3 (grabber.position.x, grabber.position.y, grabber.position.z);
//			transform.position = pos;
//		}
	}

	public void pickup (GameObject grabber)
	{
//		this.grabber = grabber;
//		holding = !holding;
		transform.parent = grabber.transform;
	}
}
