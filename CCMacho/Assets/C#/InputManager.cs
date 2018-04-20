//プレイヤーにつける
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

	ActionCharacter actionCharacter = null;

	// Use this for initialization
	void Start()
	{
		actionCharacter = GetComponent<ActionCharacter>();

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("jump");
			actionCharacter.Jump();

		}else if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("sliding");
			actionCharacter.Sliding();
		}
	}
}
