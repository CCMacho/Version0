using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCollision : MonoBehaviour
{

	ActionCharacter actionCharacter;
	void Start()
	{
		actionCharacter = transform.parent.GetComponent<ActionCharacter>();


	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerStay(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " reg touch");
		switch (other_.transform.tag)
		{
			case "Ground":
				actionCharacter.IsGround(true);
				break;
			case "Box":
				actionCharacter.IsGround(true);
				break;
		}
	}

	private void OnTriggerEnter(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " reg touch");
		switch (other_.transform.tag)
		{
			case "Ground":
				actionCharacter.IsGround(true);
				break;
			case "Box":
				actionCharacter.IsGround(true);
				break;
		}
	}

	private void OnTriggerExit(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " reg touch");
		switch (other_.transform.tag)
		{
			case "Ground":
				actionCharacter.IsGround(false);
				break;
			case "Box":
				actionCharacter.IsGround(false);
				break;
		}
	}
}
