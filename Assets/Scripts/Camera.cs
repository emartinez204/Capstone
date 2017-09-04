using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public GameObject focus;
	private Vector3 offset;


	void Start ()
	{
		offset = transform.position - focus.transform.position;
		offset.y += 3;
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = focus.transform.position + offset;

	}
}
