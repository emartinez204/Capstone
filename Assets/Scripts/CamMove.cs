using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class CamMove : MonoBehaviour
{
	public GameObject focus;
	private Vector3 offset;

	public float offY;
	public float distance;

	public Material transparent;
	public Material originalMat;

	private float rotateH;
	private float rotateV;

	LayerMask mask;

	public GameObject curObj = null;
	public GameObject prevObj = null;

	public GameObject[] clippables;


	void Start ()
	{
		offset = transform.position - focus.transform.position;
		offset.y = offY;
		offset.z = -distance;
		offset.x = 0;

		mask = 1 << LayerMask.NameToLayer ("Clippable");

		clippables = GetClippableWalls ();

	}

	GameObject[] GetClippableWalls ()
	{
		GameObject[] gos = FindObjectsOfType (typeof(GameObject)) as GameObject[];
		List<GameObject> walls = new List<GameObject> ();

		for (int i = 0; i < gos.Length; i++) {
			if (gos [i].layer == 9) {
				walls.Add (gos [i]);
			}
		}
		return walls.ToArray ();
	}


	void LateUpdate ()
	{
		//follows player
		transform.position = focus.transform.position + offset;

		//rotate camera
		if (GameManager.instance.usingController) {
			rotateH = Input.GetAxis ("RotateCamHJ");
			rotateV = Input.GetAxis ("RotateCamVJ");
		} else {
			rotateH = Input.GetAxis ("RotateCamHK");
			rotateV = Input.GetAxis ("RotateCamVK");
		}

		float lookUp = rotateV * 30 * Time.deltaTime;

		transform.RotateAround (focus.transform.position, Vector3.up, rotateH * 30 * Time.deltaTime);
		transform.RotateAround (focus.transform.position, transform.right, lookUp);

//		Vector3 angles = transform.eulerAngles;
//		angles.x += lookUp;
//		transform.eulerAngles = angles;

		offset = transform.position - focus.transform.position;

		showWalls ();

		RaycastHit hit;
		if (Physics.Linecast (transform.position, focus.transform.position, out hit, mask)) {
			//hit.transform.gameObject.GetComponent<Renderer> ().material = transparent;
			hit.transform.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		} 

			
	}

	void showWalls ()
	{
		for (int i = 0; i < clippables.Length; i++) {
			//clippables [i].GetComponent<Renderer> ().material = originalMat;
			clippables [i].GetComponent<MeshRenderer> ().enabled = true;
		}
	}
		
}
