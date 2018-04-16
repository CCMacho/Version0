using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0f,0f,transform.position.z + 1f);
	}
}
