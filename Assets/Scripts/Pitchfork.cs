using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pitchfork : MonoBehaviour
{
	bool holding = false;

	public GameObject grabber;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (holding) {
			
		}
	}

	public void pickup ()
	{
		holding = !holding;
		this.transform.parent = grabber.transform;
	}
}
