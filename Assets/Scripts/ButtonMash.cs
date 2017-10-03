using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMash : MonoBehaviour
{

	public Sprite[] xboxBtns;
	public Sprite[] keyBtns;

	public Image LoadingBar;
	public Image CenterBtn;

	private Sprite[] btns;


	void Start ()
	{

		if (GameManager.instance.usingController) {
			UseArray (xboxBtns);
		} else {
			UseArray (keyBtns);
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void UseArray (Sprite[] arr)
	{
		for (int i = 0; i < arr.Length; i++) {
			btns [i] = arr [i];
		}
	}
}
