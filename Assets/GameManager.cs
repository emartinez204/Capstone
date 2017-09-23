using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public bool DEBUG;
	public bool usingController;

	public bool musicOn;
	public float musicVolume;

	public Camera cam1;
	public Camera cam2;


	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		//default
		usingController = false;

		if (DEBUG)
			showCam2 ();
		else
			showCam1 ();

		musicOn = true;
		musicVolume = 0.5f;

	}

	public void showCam1 ()
	{
		cam1.enabled = true;
		cam2.enabled = false;
	}

	public void showCam2 ()
	{
		cam1.enabled = false;
		cam2.enabled = true;
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
