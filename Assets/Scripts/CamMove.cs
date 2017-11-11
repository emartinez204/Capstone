using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
	private float zoom;

	LayerMask mask;

	public GameObject curObj = null;
	public GameObject prevObj = null;

	public GameObject[] clippables;

	private float lookHorizontal;
	private float lookUp;


	void Start ()
	{
//		offset = transform.position - focus.transform.position;
//		offset.y = offY;
//		offset.z = -distance;
//		offset.x = 0;

	
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
			zoom = Input.GetAxis ("ZoomJ");
		} else {
			rotateH = Input.GetAxis ("RotateCamHK");
			rotateV = Input.GetAxis ("RotateCamVK");
			zoom = Input.GetAxis ("ZoomK");
		}
		distance += zoom;
		distance = Mathf.Clamp (distance, 4, 10);

		transform.position = focus.transform.position - (Vector3.right * distance) + (Vector3.up * offY);
		transform.rotation = Quaternion.Euler (0, 90, 0);

//		transform.position = focus.transform.position - (Vector3.forward * distance) + (Vector3.up * offY);
//		transform.rotation = Quaternion.identity;

		lookHorizontal += rotateH * Time.deltaTime * 30;
		lookUp += rotateV * Time.deltaTime * 30;

		lookHorizontal = Mathf.Repeat (lookHorizontal, 360);
		lookUp = Mathf.Clamp (lookUp, -5, 80);

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
