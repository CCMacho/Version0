using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivePoint : MonoBehaviour {

    public GameObject Center;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Man")
        {
            other.GetComponent<ManMove>().NextMove(Center);
        }
    }
}
