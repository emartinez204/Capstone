using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pitchfork : MonoBehaviour
{
	bool holding = false;

	public GameObject grabber;

	private string interact;

	
	// Update is called once per frame
	void Update ()
	{
		checkController ();

		if (holding && !GameManager.instance.game1 && !GameManager.instance.game2 && !GameManager.instance.game3) {
			if (Input.GetKeyDown (interact)) {
				putDown ();
			}
		}
	}

	public void pickup ()
	{
		holding = true;
		this.transform.parent = grabber.transform;
	}

	public void putDown ()
	{
		holding = false;
		this.transform.parent = null;
	}

	private void checkController ()
	{
		if (GameManager.instance.usingController) {
			interact = "joystick button 17"; //B

		} else {
			interact = "r";
		}

	}
}
