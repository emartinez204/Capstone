using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMash : MonoBehaviour
{
	public bool beginButtonMash;
	public Sprite[] xboxBtns;
	public Sprite[] keyBtns;

	public GameObject ButtonPressTimer;
	public Image LoadingBar;
	public Image CenterBtn;

	private Sprite[] btns;

	public bool userInputMatches = false;



	void Start ()
	{
		btns = new Sprite[4];
		CenterBtn.GetComponent<Image> ();
		LoadingBar.GetComponent<Image> ();

		if (GameManager.instance.usingController) {
			UseArray (xboxBtns);
		} else {
			UseArray (keyBtns);
		}

		randomlyPickBtn ();
		showButton (false);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (beginButtonMash) {
			showButton (true);


			StartCoroutine (fillBar ());

			checkForUserInput ();

			if (userInputMatches) {
				StopCoroutine (fillBar ());
				StartCoroutine (fillBar ());
				userInputMatches = false;
			} 


		} else {
			showButton (false);
		}
		
	}

	void UseArray (Sprite[] arr)
	{
		for (int i = 0; i < arr.Length; i++) {
			btns [i] = arr [i];
		}
	}

	public void showButton (bool val)
	{
		ButtonPressTimer.SetActive (val);
	}

	void randomlyPickBtn ()
	{
		int rand = Random.Range (0, 3);
		CenterBtn.sprite = btns [rand];
	}

	void checkForUserInput ()
	{
		string curBtn = CenterBtn.sprite.ToString ();
		string btn2Press = "space";

		if (curBtn == "aBtn") {
			btn2Press = "joystick button 16";
		} else if (curBtn == "bBtn") {
			btn2Press = "joystick button 17";
		} else if (curBtn == "xBtn") {
			btn2Press = "joystick button 18";
		} else if (curBtn == "yBtn") {
			btn2Press = "joystick button 19";
		} else if (curBtn == "arrowUp") {
			btn2Press = "UpArrow";
		} else if (curBtn == "arrowDown") {
			btn2Press = "DownArrow";
		} else if (curBtn == "arrowLeft") {
			btn2Press = "LeftArrow";
		} else if (curBtn == "arrowRight") {
			btn2Press = "RightArrow";
		}

		if (Input.GetKeyDown (btn2Press)) {
			userInputMatches = true;
		}
	}


	IEnumerator fillBar ()
	{
		//LoadingBar.fillAmount = Mathf.Lerp (0f, 1f, 0.4f * Time.time);
		LoadingBar.fillAmount += 0.015f;
		yield return new WaitForSecondsRealtime (0.1f);
		if (LoadingBar.fillAmount >= 0.75f)
			LoadingBar.color = Color.red;
		if (LoadingBar.fillAmount == 1f) {
			LoadingBar.fillAmount = 0f;
			LoadingBar.color = Color.blue;
			randomlyPickBtn ();
		}

	}

}