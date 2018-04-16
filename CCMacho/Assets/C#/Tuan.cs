using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuan : MonoBehaviour {

	[SerializeField]
	float speed = 0.5f;
	[SerializeField]
	float speedX = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(speedX, speed, 0));
	}
}
