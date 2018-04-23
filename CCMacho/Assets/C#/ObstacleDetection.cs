//障害物認識用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleDetection : MonoBehaviour
{

	[SerializeField]
	Text bodyCollisionText  = null;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	public void OnCollisionEnter(Collision other_)
	{
		switch (other_.transform.tag)
		{
			case "Box":
				bodyCollisionText.text = "Box";
				break;
		}

	}
}

