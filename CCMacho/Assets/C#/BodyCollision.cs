using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour {

	InputManager inputManager;

	// Use this for initialization
	void Start () {
		inputManager = FindObjectOfType<InputManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other_)
	{
		Debug.Log(other_.transform.tag + " body touch");

		switch (other_.transform.tag)
		{
			case "Ground":
				inputManager.IsGround(true);
				break;
			case "Box":
				inputManager.Hit();
				break;
		}

	}
}
