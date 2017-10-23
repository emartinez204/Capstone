using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Specialized;
using System.Threading;


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

	private float lookHorizontal;
	private float lookUp;


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
		if (GameManager.instance.usingController) {
			rotateH = Input.GetAxis ("RotateCamHJ");
			rotateV = Input.GetAxis ("RotateCamVJ");
		} else {
			rotateH = Input.GetAxis ("RotateCamHK");
			rotateV = Input.GetAxis ("RotateCamVK");
		}

		transform.position = focus.transform.position - (Vector3.forward * distance) + (Vector3.up * offY);
		transform.rotation = Quaternion.identity;

		lookHorizontal += rotateH * Time.time;
		lookUp += rotateV * Time.time;

		lookHorizontal = Mathf.Repeat (lookHorizontal, 360);
		lookUp = Mathf.Clamp (lookUp, 0, 80);

		transform.RotateAround (focus.transform.position, Vector3.up, lookHorizontal);
		transform.RotateAround (focus.transform.position, transform.right, lookUp);


//		transform.position = focus.transform.position + offset;
//
//
//		float lookUp = rotateV * 30 * Time.deltaTime;
//
//		transform.RotateAround (focus.transform.position, Vector3.up, rotateH * 30 * Time.deltaTime);
//		transform.RotateAround (focus.transform.position, transform.right, lookUp);
//
//	
//
//		offset = transform.position - focus.transform.position;



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
