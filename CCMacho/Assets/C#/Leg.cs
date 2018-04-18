using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour {

	InputManager inputManager;
	void Start () {
		inputManager = FindObjectOfType<InputManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionStay(Collision other_)
	{
		if (other_.transform.tag == "Box")
		{
			inputManager.IsGround(true);
		}
	}
}
