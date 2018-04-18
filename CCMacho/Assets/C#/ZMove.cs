using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMove : MonoBehaviour {

	[SerializeField]
	float speedX = 1.0f;
    [SerializeField]
    float speedZ = 1.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
 		transform.Translate(speedX * Time.deltaTime, 0, speedZ * Time.deltaTime);
 	}
}
