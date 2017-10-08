using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEditor;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public bool DEBUG;
	public bool usingController;

	public GameObject player;

	public bool musicOn;
	public float musicVolume;

	public Camera canvasCam;
	public Camera playerCam;
	public Camera movieCam;
	public Camera miniGame1;
	public Camera miniGame2;
	public Camera miniGame3;


	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		//default
		//usingController = false;

		if (DEBUG)
			useCamera ("player");
		else
			useCamera ("canvas");

		musicOn = true;
		musicVolume = 0.5f;

	}

	public void useCamera (string cam)
	{
		disableCams ();
		switch (cam) {
		case "canvas":
			canvasCam.enabled = true;
			break;
		case "player":
			playerCam.enabled = true;
			break;
		case "movie":
			movieCam.enabled = true;
			break;
		case "miniGame1":
			miniGame1.enabled = true;
			break;
		case "miniGame2":
			miniGame2.enabled = true;
			break;
		case "miniGame3":
			miniGame3.enabled = true;
			break;
		}


	}

	private void disableCams ()
	{
		canvasCam.enabled = false;
		playerCam.enabled = false;
		movieCam.enabled = false;
		miniGame1.enabled = false;
		miniGame2.enabled = false;
		miniGame3.enabled = false;
	}

	public void toggleController ()
	{
		usingController = !usingController;
	}

	public void testing ()
	{
		print ("Clicking the item");
	}

	public void showElement (GameObject elem)
	{
		elem.SetActive (true);
	}

	public void hideElement (GameObject elem)
	{
		elem.SetActive (false);
	}

	public void toggleMusic (Toggle tog)
	{
		musicOn = tog.isOn;
	}

	public void setMusicVolume (Slider slide)
	{
		musicVolume = slide.value;
	}
		

}
