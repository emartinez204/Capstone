using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
	public Text itemTxt;

	private string buttonTxt;
	private string openDoor;

	void Update ()
	{
		if (GameManager.instance.usingController) {
			openDoor = "joystick button 16";
			buttonTxt = "Press A";
		} else {
			openDoor = "e";
			buttonTxt = "Press E";
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Interactable") {
			itemTxt.text = "This is a " + other.gameObject.name.ToString ();
		}

		if (other.tag == "Door") {
			itemTxt.text = "Enter next room? " + buttonTxt;
			other.GetComponent<Door> ().Move ();
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Door") {

			if (Input.GetKeyDown (openDoor)) {
				print ("hitting enter");
				//open door

				if (other.GetComponent<Door> ().RotationPending == false)
					StartCoroutine (other.GetComponent<Door> ().Move ());
				
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		itemTxt.text = "";
	}
}
