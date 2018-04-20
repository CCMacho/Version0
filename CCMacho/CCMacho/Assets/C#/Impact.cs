using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour {


    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

     void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Goal")
        {
            if(transform.position.x > 0)
            {
                gameManager.AddRedPoint();
			}
			else if (transform.position.x < 0)
			{
				gameManager.AddBluePoint();
				Debug.Log("sjaiohdf;oid");

			}

			transform.position = new Vector3(0, 12f, 0f);
        }

    }
}
