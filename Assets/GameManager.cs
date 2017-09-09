using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public bool usingController;


	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

}
