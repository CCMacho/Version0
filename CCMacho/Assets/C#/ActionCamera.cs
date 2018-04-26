﻿//カメラ用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCamera : MonoBehaviour {

	Vector3 startPosition = Vector3.zero;
	Quaternion startRotation = Quaternion.identity;

	[SerializeField]
	Vector3 actionPosition = new Vector3(3f, 2f, 2f);
	[SerializeField]
	Quaternion actionRotationRadian = new Quaternion(10f * Mathf.PI / 180f, -120f * Mathf.PI / 180f, 2f * Mathf.PI / 180f, 1);


	// Use this for initialization
	void Start () {

		startPosition = transform.localPosition;
		startRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//アクションが見やすい位置に移動
	public void ActionCameraOn()
	{
		transform.transform.localPosition = actionPosition;
		transform.localRotation = actionRotationRadian;
	}

	//元に戻す
	public void ActionCameraOff()
	{
		transform.localPosition = startPosition;
		transform.localRotation = startRotation;
	}
}
