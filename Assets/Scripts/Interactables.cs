using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
	public Text itemTxt;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Interactable") {
			itemTxt.text = "This is a " + other.gameObject.name.ToString ();
		}
	}

	void OnTriggerExit (Collider other)
	{
		itemTxt.text = "";
	}
}
