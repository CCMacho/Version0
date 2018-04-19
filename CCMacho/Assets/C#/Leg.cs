using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCollision : MonoBehaviour {

	InputManager inputManager;
	void Start () {
		inputManager = FindObjectOfType<InputManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other_)
	{
        Debug.Log(other_.transform.tag + " reg touch");
		switch (other_.transform.tag) {
			case "Ground":
				inputManager.IsGround(true);
				break;
			case "Box":
				inputManager.IsGround(true);
				break;
		}
	}
}
