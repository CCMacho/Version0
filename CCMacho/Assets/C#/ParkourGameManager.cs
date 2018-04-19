using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkourGameManager : MonoBehaviour {

	[SerializeField]
	float commandTimeLength = 10f;
	float commandTime = 0f;
	float time = 0;

	//シングルトン
	Text commandTimeText = null;
	TimeButton timeButton = null;

	// Use this for initialization
	void Start () {
		commandTimeText = GameObject.Find("CommandTime").GetComponent<Text>();
		timeButton = FindObjectOfType<TimeButton>();

	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		commandTime -= Time.deltaTime;
		if(commandTime < 0f)
		{
			commandTimeText.enabled = false;
			timeButton.StartTime();
		}
	}

	public void CommandTimeOn()
	{
		commandTime = commandTimeLength;
		commandTimeText.enabled = true;
		timeButton.SlowTime();

	}
}
