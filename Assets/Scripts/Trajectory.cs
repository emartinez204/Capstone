using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Security.AccessControl;

public class Trajectory : MonoBehaviour
{
	public GameObject trajectoryBar;
	public Slider traj;
	public Text trajText;
	public bool moveSlider = false;

	private string stopButton;
	private float throwValue;

	//Chances to hit bird
	private int numThrows = 5;

	private int curThrows = 0;

	void Start ()
	{
		checkController ();

		traj.value = 0;

		showTrajBar (false);
	}


	void Update ()
	{
		checkController ();

		if (moveSlider) {
			showTrajBar (true);
			traj.value = Mathf.PingPong (Time.time, 1);

			if (Input.GetKeyDown (stopButton)) {
				curThrows++;
				moveSlider = false;
				throwValue = traj.value;

				//animation of robot throwing pitchfork at bird
				StartCoroutine (wait ());

			}

		}
		
	}

	IEnumerator wait ()
	{
		
		if (curThrows == numThrows) {
			showTrajBar (false);
			GameManager.instance.endMiniGame (true);
		} else {
			yield return new WaitForSeconds (3);
			moveSlider = true;
			//once animation over, start slider again
		}
	}

	void checkController ()
	{
		if (GameManager.instance.usingController) {
			stopButton = "joystick button 16";
			trajText.text = "HIT 'A' TO STOP";
		} else {
			stopButton = "space";
			trajText.text = "HIT 'SPACEBAR' TO STOP";
		}
	}

	public void showTrajBar (bool val)
	{
		trajectoryBar.SetActive (val);
	}


	public void reset ()
	{
		traj.value = 0;
		showTrajBar (false);
		moveSlider = false;
		curThrows = 0;
	}

}
