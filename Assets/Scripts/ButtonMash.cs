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

	public Sprite[] btns;


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


			increaseTimer ();


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

	void increaseTimer ()
	{
		print ("in increase timer");



		StartCoroutine (fillBar ());


	}

	IEnumerator fillBar ()
	{
		//LoadingBar.fillAmount = Mathf.Lerp (0f, 1f, 0.4f * Time.time);
		LoadingBar.fillAmount += 0.02f;
		yield return new WaitForSecondsRealtime (0.1f);
		if (LoadingBar.fillAmount == 1f) {
			LoadingBar.fillAmount = 0f;
		}
	}

}