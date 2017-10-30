using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (AudioSource))]

public class Video : MonoBehaviour
{
	public MovieTexture[] movie;
	private int curVideo = 0;

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
		if (started && !movie [curVideo].isPlaying) {
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
		GameManager.instance.useCamera ("movie");
		movie [curVideo].Play ();
		started = true;
		this.backCam = backCam;

	}

	public void reset ()
	{
		curVideo = 0;
		GetComponent<Renderer> ().material.mainTexture = movie [curVideo];
	}
}
