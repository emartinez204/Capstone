using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
	public Text itemTxt;

	private string buttonTxt;
	private string interact;

	void Update ()
	{
		if (GameManager.instance.usingController) {
			interact = "joystick button 16";
			buttonTxt = "Press A";
		} else {
			interact = "e";
			buttonTxt = "Press E";
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Interactable") {
			itemTxt.text = other.gameObject.name.ToString ().ToUpper () + ". . . ";

			if (other.gameObject.name.ToString () == "pitchfork") {
				itemTxt.text += buttonTxt + " to pick up.";
			}
		}

		if (other.tag == "Door") {
			itemTxt.text = "Enter next room? " + buttonTxt;
			other.GetComponent<Door> ().Move ();
		}

	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Door") {

			if (Input.GetKeyDown (interact)) {
				print ("hitting enter");
				//open door

				if (other.GetComponent<Door> ().RotationPending == false)
					StartCoroutine (other.GetComponent<Door> ().Move ());
				
			}
		}

		if (other.gameObject.name.ToString () == "pitchfork") {
			if (Input.GetKeyDown (interact)) {
				GameManager.instance.resetMats ();
				other.GetComponent<Pitchfork> ().pickup ();
				GameManager.instance.nextItem ();
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		itemTxt.text = "";
	}
}
