using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (AudioSource))]

public class Video : MonoBehaviour
{
	public MovieTexture[] movie;
	public int curVideo = 0;

	public bool started = false;
	private string backCam = "player";

	// Use this for initialization
	void Start ()
	{
		GetComponent<Renderer> ().material.mainTexture = movie [0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		skip ();

		if (started && !movie [curVideo].isPlaying) {
			movie [curVideo].Stop ();
			GameManager.instance.useCamera (backCam);

			started = false;
		}
		
	}

	public void setNextVideo ()
	{
		curVideo++;
		GetComponent<Renderer> ().material.mainTexture = movie [curVideo];
	}

	public void playVideo (string backCam)
	{
		print ("play video 1");
		GameManager.instance.useCamera ("movie");
		movie [curVideo].Play ();
		started = true;
		this.backCam = backCam;
		print ("play video 2");
	}

	private void skip ()
	{
		if (started) {
			if (GameManager.instance.usingController) {
				if (Input.GetKeyDown ("joystick button 16")) {
					movie [curVideo].Stop ();
					GameManager.instance.useCamera (backCam);
					started = false;
				}
			} else {
				if (Input.GetKeyDown ("space")) {
					movie [curVideo].Stop ();
					GameManager.instance.useCamera (backCam);
					started = false;
				}
			}

		}
	}

	public void reset ()
	{
		curVideo = 0;
		GetComponent<Renderer> ().material.mainTexture = movie [curVideo];
	}
}
