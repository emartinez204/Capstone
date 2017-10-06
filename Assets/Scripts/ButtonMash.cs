using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonMash : MonoBehaviour
{
	public bool beginButtonMash;
	public Sprite[] xboxBtns;
	public Sprite[] keyBtns;

	public GameObject ButtonPressTimer;
	public Image LoadingBar;
	public Image CenterBtn;

	private Sprite[] btns;
	private string[] keys;

	public string[] xboxKeys;
	public string[] keyKeys;

	public bool userInputMatches = false;

	private int correct = 0;



	void Start ()
	{
		btns = new Sprite[4];
		keys = new String[4];

		CenterBtn.GetComponent<Image> ();
		LoadingBar.GetComponent<Image> ();

		if (GameManager.instance.usingController) {
			UseArray (xboxBtns, xboxKeys);
		} else {
			UseArray (keyBtns, keyKeys);
		}

		randomlyPickBtn ();
		showButton (false);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (beginButtonMash) {
			showButton (true);


			fillBar ();

			checkForUserInput ();

			if (userInputMatches) {
				correct++;
				LoadingBar.fillAmount = 0;
				randomlyPickBtn ();
				userInputMatches = false;
			} 


		} else {
			showButton (false);
		}
		
	}

	void UseArray (Sprite[] arr, string[] keys)
	{
		for (int i = 0; i < arr.Length; i++) {
			btns [i] = arr [i];
			this.keys [i] = keys [i];
		}
	}

	public void showButton (bool val)
	{
		ButtonPressTimer.SetActive (val);
	}

	void randomlyPickBtn ()
	{
		int rand = UnityEngine.Random.Range (0, 3);
		CenterBtn.sprite = btns [rand];
	}

	void checkForUserInput ()
	{
		Sprite curBtn = CenterBtn.sprite;
		string btn2Press = "";

		for (var i = 0; i < keys.Length; i++) {
			if (btns [i] == curBtn) {
				btn2Press = keys [i];
			}
		}
			
		if (Input.GetKeyDown (btn2Press)) {
			print ("Pressed correct button");
			userInputMatches = true;
		}
	}


	void fillBar ()
	{
		LoadingBar.fillAmount += Time.deltaTime * 0.6f;
	
		if (LoadingBar.fillAmount >= 0.75f)
			LoadingBar.color = Color.red;
		if (LoadingBar.fillAmount == 1f) {
			LoadingBar.fillAmount = 0f;
			LoadingBar.color = Color.blue;
			randomlyPickBtn ();
		}

	}

}