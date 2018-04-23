using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour {

	ActionCharacter actionCharacter;

	// Use this for initialization
	void Start () {
		actionCharacter = transform.parent.GetComponent<ActionCharacter>();

	}

	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " body touch");

		switch (other_.transform.tag)
		{
			case "Ground":
				actionCharacter.IsGround(true);
				break;
			case "Box":
				actionCharacter.Hit();
				break;
		}

	}

	private void OnTriggerEnter(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " body touch");

		switch (other_.transform.tag)
		{
			case "Ground":
				actionCharacter.IsGround(true);
				break;
			case "Box":
				actionCharacter.Hit();
				break;
		}

	}
}
