using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEditor;
using Invector.CharacterController;
using System;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public bool DEBUG;
	public bool usingController;


	public GameObject player;
	public GameObject startPoint;
	public GameObject arrow;

	public bool musicOn;
	public float musicVolume;

	public GameObject settingsButton;
	public Canvas gameItems;
	public GameObject videoCanvas;

	public string currentCam;
	public Camera canvasCam;
	public Camera playerCam;
	public Camera movieCam;
	public Camera miniGame1;
	public Camera miniGame2;
	public Camera miniGame3;

	public GameObject[] storyItems;
	public GameObject currItem;

	public Material[] regularMats;
	public Material[] glowMats;


	private int currItemIndex = 0;


	private ButtonMash buttonMash;
	private Trajectory trajectory;

	public bool isNextDay = false;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		//DontDestroyOnLoad (gameObject);

		buttonMash = GetComponent<ButtonMash> ();
		trajectory = GetComponent<Trajectory> ();

		//default
		//usingController = false;

//		if (DEBUG)
//			useCamera ("player");
//		else


//		player.GetComponent<vThirdPersonController> ().enabled = false;
//		player.GetComponent<vThirdPersonInput> ().enabled = false;
//		playerCam.enabled = false;



		reset ();

	}


	public void movePlayer (bool val)
	{
		player.GetComponent<vThirdPersonInput> ().enabled = val;

		if (val)
			player.GetComponent<Player> ().removeConstraints ();
	}

	public IEnumerator startMiniGame1 ()
	{
		print ("mini game 1");
		settingsButton.SetActive (false);
		while (videoCanvas.GetComponent<Video> ().started == true) {
			yield return new WaitForSeconds (0.1f);
		}

		print ("mini game 1");
		nextItem ();

		player.GetComponent<vThirdPersonInput> ().enabled = false;
		player.GetComponent<Player> ().setPos (1);

		gameItems.worldCamera = miniGame1;

	
		yield return new WaitForSeconds (2f);
		buttonMash.beginButtonMash = true;
	
	}

	public void endMiniGame ()
	{
		gameItems.worldCamera = playerCam;
		useCamera ("player");
		movePlayer (true);
		settingsButton.SetActive (true);
	}

	public IEnumerator startMiniGame2 ()
	{
		print ("mini game 2");
		settingsButton.SetActive (false);
		while (videoCanvas.GetComponent<Video> ().started == true) {
			yield return new WaitForSeconds (0.1f);
		}

		print ("mini game 2");
		nextItem ();

		movePlayer (false);
		player.GetComponent<Player> ().setPos (2);

		gameItems.worldCamera = miniGame2;


		yield return new WaitForSeconds (2f);
		buttonMash.beginButtonMash = true;
	}

	public IEnumerator startMiniGame3 ()
	{
		print ("mini game 3");
		settingsButton.SetActive (false);
		while (videoCanvas.GetComponent<Video> ().started == true) {
			yield return new WaitForSeconds (0.1f);
		}

		print ("mini game 3");
	
		movePlayer (false);
		player.GetComponent<Player> ().setPos (3);

		gameItems.worldCamera = miniGame3;


		yield return new WaitForSeconds (2f);
		trajectory.moveSlider = true;
	}

	public IEnumerator waitForVideo (bool nDay)
	{
		print ("wait 1");
		while (videoCanvas.GetComponent<Video> ().started == true) {
			yield return new WaitForSeconds (0.1f);
		}
		print ("wait 2");


		
		yield return new WaitForSeconds (0.1f);
		nextItem ();

		if (nDay)
			nextDay ();

	}

	public void nextDay ()
	{
		isNextDay = true;
		player.transform.position = startPoint.transform.position;
	}


	public void setNextVideo ()
	{
		videoCanvas.GetComponent<Video> ().setNextVideo ();
	}

	public void playVideo (string backCam)
	{
		
		videoCanvas.GetComponent<Video> ().playVideo (backCam);
		//yield return new WaitForSeconds (1f);
	}

	public void resetMats ()
	{
		for (int i = 0; i < storyItems.Length; i++) {
			storyItems [i].GetComponent<MeshRenderer> ().material = regularMats [i];
		}
	}

	public void setCurrItem (int index)
	{
		resetMats ();
		currItem = storyItems [index];
		currItem.GetComponent<MeshRenderer> ().material = glowMats [index];
		arrow.GetComponent<Float> ().setPos (new Vector3 (currItem.transform.position.x, currItem.transform.position.y + 2.5f, currItem.transform.position.z));

	}


	public void showArrow (bool val)
	{
		arrow.SetActive (val);
	}

	public void nextItem ()
	{
		currItemIndex++;
		setCurrItem (currItemIndex);
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

		currentCam = cam;
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

	public void reset ()
	{
		musicOn = true;
		musicVolume = 0.5f;
		currItemIndex = 0;
		setCurrItem (currItemIndex);

		useCamera ("canvas");

		settingsButton.SetActive (true);

		player.transform.position = startPoint.transform.position;
		//call all other reset functions
	}

}
