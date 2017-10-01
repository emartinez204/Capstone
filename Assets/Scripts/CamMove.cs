using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
	public GameObject focus;
	private Vector3 offset;

	public float offY;
	public float distance;

	private float rotateH;
	private float rotateV;

	private float maxUp = 60F;
	private float maxDown = -60F;


	private Quaternion originalRotation;


	void Start ()
	{
		originalRotation = transform.localRotation;

		offset = transform.position - focus.transform.position;
		offset.y = offY;
		offset.z = -distance;
		offset.x = 0;

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

		float lookUp = rotateV * 30 * Time.deltaTime, maxDown, maxUp;

		transform.RotateAround (focus.transform.position, Vector3.up, rotateH * 30 * Time.deltaTime);
		transform.RotateAround (focus.transform.position, transform.right, lookUp);


		offset = transform.position - focus.transform.position;

	}

	static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}

}
