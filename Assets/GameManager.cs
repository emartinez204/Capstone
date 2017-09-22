using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public bool DEBUG;
	public bool usingController;

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
		

}
