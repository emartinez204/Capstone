using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

	public Transform spot1;
	public Transform spot2;
	public Transform spot3;


	void Start ()
	{
		setPos (1);
	}

	void Update ()
	{
		if (GameManager.instance.game1) {
			setPos (1);
		} else if (GameManager.instance.game2) {
			setPos (2);
		} else if (GameManager.instance.game3) {
			setPos (3);
		}
		
	}

	public void setPos (int spotNum)
	{
		if (spotNum == 1) {
			transform.position = spot1.position;
			transform.rotation = spot1.rotation;
		} else if (spotNum == 2) {
			transform.position = spot2.position;
			transform.rotation = spot2.rotation;
		} else if (spotNum == 3) {
			transform.position = spot3.position;
			transform.rotation = spot3.rotation;
		}
	}


}
