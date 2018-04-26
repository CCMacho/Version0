//時間変更用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimeButton : MonoBehaviour {

	float slowMagnification = 0.5f;
	ParkourGameManager parkourGameManager;

	// Use this for initialization
	void Start () {
		parkourGameManager = FindObjectOfType<ParkourGameManager>();
		slowMagnification = parkourGameManager.SlowMagnification();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//時間を止める
	public void StopTime(){
		Time.timeScale = 0f;

		
		Debug.Log("StopTime");
	}

	//時間を通常通りにする
 	public void StartTime(){
		Time.timeScale = 1f;

	}

	//スローにする
	public void SlowTime(){
		Time.timeScale = slowMagnification;
		
	}


}