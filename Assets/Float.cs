using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Float : MonoBehaviour
{

	private Vector3 tempPos;

	private bool floating = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (floating) {
			tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * 1f) * 0.03f;
			transform.position = tempPos;
		}
		
	}

	public void setPos (Vector3 pos)
	{
		floating = false;
		tempPos = pos;
		floating = true;
	}
}
