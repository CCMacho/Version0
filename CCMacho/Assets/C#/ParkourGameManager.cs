using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkourGameManager : MonoBehaviour {

	[SerializeField]
	float commandTimeLength = 10f;
	float commandTime = 0f;
	[SerializeField]
	float actionTimeLength = 2f;
	float actionTime = 0f;
	float time = 0;
	[SerializeField]
	float baseActionPoint = 0.1f;
	int score = 0;
	int displayScore = 0;
	int totalScore = 0;

	//シングルトン
	Text commandTimeText = null;
	TimeButton timeButton = null;
	Slider actionGauge = null;
	Text displayScoreText = null;
	Text totalScoreText = null;


	// Use this for initialization
	void Start () {
		commandTimeText = GameObject.Find("CommandTime").GetComponent<Text>();
		timeButton = FindObjectOfType<TimeButton>();
		commandTimeText.enabled = false;
		actionGauge = GameObject.Find("ActionGauge").GetComponent<Slider>();
		displayScoreText = GameObject.Find("Score").GetComponent<Text>();
		totalScoreText = GameObject.Find("TotalScore").GetComponent<Text>();


	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		commandTime -= Time.deltaTime;
		if(commandTime < 0f && commandTimeText.enabled)
		{

			commandTimeText.enabled = false;
			timeButton.StartTime();

			FindObjectOfType<ActionCamera>().ActionCameraOn();
			actionTime = actionTimeLength;
		}

		actionTime -= Time.deltaTime;

		if(actionTime < 0f)
		{
			FindObjectOfType<ActionCamera>().ActionCameraOff();
		}
		else
		{
			actionGauge.value += baseActionPoint * Time.deltaTime;
			AddScore((int)(baseActionPoint * Time.deltaTime * 1000f));
		}

		if(score != displayScore)
		{
			displayScore += score / (displayScore + 1);
			displayScoreText.text = "Just Now Action Score:" + displayScore * 10;
		}
		else
		{

			score = displayScore = 0;
			displayScoreText.text = "Just Now Action Score:" + 0;

			
		}
	}

	public void CommandTimeOn()
	{
		commandTime = commandTimeLength;
		commandTimeText.enabled = true;
		timeButton.SlowTime();

	}

	public void AddScore(int num_)
	{
		score += num_;
	}
}
