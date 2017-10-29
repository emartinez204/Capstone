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
	public GameObject arrow;

	public bool musicOn;
	public float musicVolume;

	public Canvas gameItems;
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

		musicOn = true;
		musicVolume = 0.5f;

		setCurrItem (currItemIndex);

		useCamera ("canvas");

	}

	public void startMiniGame1 ()
	{
		print ("mini game 1");
		nextItem ();

		player.GetComponent<vThirdPersonInput> ().enabled = false;
		player.GetComponent<Player> ().setPos (1);
		//cutscene
		//useCamera("movie");

		gameItems.worldCamera = miniGame1;
		useCamera ("miniGame1");

		//StartCoroutine (miniGameOne ());


	}

	public void endMiniGame ()
	{
		gameItems.worldCamera = playerCam;
		useCamera ("player");
		player.GetComponent<vThirdPersonInput> ().enabled = true;
		player.GetComponent<Player> ().removeConstraints ();
	}

	public void startMiniGame2 ()
	{
		nextItem ();
		gameItems.worldCamera = miniGame2;
		useCamera ("miniGame2");
		buttonMash.beginButtonMash = true;
	}

	private IEnumerator miniGameOne ()
	{
		yield return new WaitForSeconds (2f);
		player.GetComponent<vThirdPersonInput> ().enabled = false;
		player.GetComponent<Player> ().setPos (1);
		//cutscene
		//useCamera("movie");

		gameItems.worldCamera = miniGame1;
		useCamera ("miniGame1");
		yield return new WaitForSeconds (2f);
		buttonMash.beginButtonMash = true;

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

		print (cam);
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
