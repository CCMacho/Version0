//頭の高さの判定用コライダー用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHeightCollision : MonoBehaviour {

	ActionCharacter actionCharacter;

	// Use this for initialization
	void Start()
	{
		actionCharacter = transform.parent.GetComponent<ActionCharacter>();

	}


	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter(Collider other_)
	{
		switch (other_.transform.tag)
		{
			case "Box":
				actionCharacter.HeadHeightBox();
				break;
		}
	}
	private void OnTriggerStay(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " HeadHeight touch");

		switch (other_.transform.tag)
		{
			case "Box":
				actionCharacter.HeadHeightBox();
				break;
		}

	}


	private void OnTriggerExit(Collider other_)
	{
		switch (other_.transform.tag)
		{
			case "Box":
				actionCharacter.HeadHeightBox(false);
				break;
		}
	}
}
