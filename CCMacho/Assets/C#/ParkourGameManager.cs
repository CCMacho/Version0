﻿//パルクールゲーム用システム統括
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
	[SerializeField]
	float slowMagnification = 0.1f;
	

	//シングルトン
	Text commandTimeText = null;
	TimeButton timeButton = null;
	Slider actionGauge = null;
	Text displayScoreText = null;
	Text totalScoreText = null;
	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		timeButton  = Instantiate(Resources.Load<GameObject>("Prefab/TimeButton")).GetComponent<TimeButton>();

		commandTimeText = GameObject.Find("CommandTime").GetComponent<Text>();
		timeButton = FindObjectOfType<TimeButton>();
		commandTimeText.enabled = false;
		actionGauge = GameObject.Find("ActionGauge").GetComponent<Slider>();
		displayScoreText = GameObject.Find("DisplayScore").GetComponent<Text>();
		totalScoreText = GameObject.Find("TotalScore").GetComponent<Text>();

		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		commandTime -= Time.deltaTime;
		if(commandTime < 0f && commandTimeText.enabled)
		{

			commandTimeText.enabled = false;
			timeButton.StartTime();
			audioSource.pitch = 1f;
			audioSource.volume = 1f;


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
            totalScore += score * 10;
            totalScoreText.text = "Total Score:" + totalScore.ToString();
			score = displayScore = 0;
			displayScoreText.text = "Just Now Action Score:" + 0;

			
		}
	}

	//コマンドタイム開始
	public void CommandTimeOn()
	{
		commandTime = commandTimeLength;
		commandTimeText.enabled = true;
		timeButton.SlowTime();
		audioSource.pitch = slowMagnification;
		audioSource.volume = 0.5f;
	}

	//スコア増加
	public void AddScore(int num_)
	{
		score += num_;
	}

	public float SlowMagnification()
	{
		return slowMagnification;
	}
}
