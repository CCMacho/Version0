using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StopTime(){
		Time.timeScale = 0f;

		
		Debug.Log("StopTime");
	}
 	public void StartTime(){
		Time.timeScale = 1f;

	}

	public void SlowTime(){
		Time.timeScale = 0.5f;

	}
}