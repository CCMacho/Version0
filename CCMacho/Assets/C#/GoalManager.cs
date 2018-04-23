//ゴール後の処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other_)
	{
		//Debug.Log(other_.transform.tag + " body touch");

		switch (other_.transform.tag)
		{
			case "Player":
				SceneManager.LoadScene("Title");
				break;
		}

	}
}
