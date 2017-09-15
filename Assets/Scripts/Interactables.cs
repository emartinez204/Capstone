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

		if (other.tag == "Door") {
			itemTxt.text = "Enter next room?";
			other.GetComponent<Door> ().Move ();
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Door") {
			if (Input.GetKeyDown ("enter")) {
				print ("hitting enter");
				//open door
				other.GetComponent<Door> ().Move ();
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		itemTxt.text = "";
	}
}
