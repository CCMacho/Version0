using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recognition : MonoBehaviour {

	GameObject spineBase = null;
	float spineBasePosition = 0f;
	[SerializeField]
	Text Status = null;

	float acceptableRangeJump = 0.8f;
	float acceptableRangeDown = 0.9f;
	float remidRange = 20f;



	// Use this for initialization
	void Start () {
		Status.text = "NowStatus:Normal";
	}
	
	// Update is called once per frame
	void Update () {

		if (spineBase == null)
		{
			spineBase = GameObject.Find("SpineBase");
			spineBasePosition = transform.position.y;
		}
		else
		{

			if (spineBase.transform.position.y > spineBasePosition + acceptableRangeJump)
			{
				Status.text = "NowStatus:Jump";

			}
			else if (spineBase.transform.position.y < spineBasePosition - acceptableRangeDown)
			{
				Status.text = "NowStatus:Down";

			}
			else
			{
				Status.text = "NowStatus:Normal";

			}
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			GameObject newSpineBase = GameObject.Find("SpineBase");

			if (remidRange > newSpineBase.transform.position.z)
			{
				spineBase = newSpineBase;
				spineBasePosition = spineBase.transform.position.y;
			}
		
		}
	}
}
