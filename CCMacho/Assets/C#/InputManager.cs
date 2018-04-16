using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    float speedY = 0f;
    float speedZ = 0.2f;

    float jumpPower = 10f;
    Rigidbody rigidbody;
    bool isGround = false;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            Jump();
        }

        transform.position = new Vector3(0f, transform.position.y, transform.position.z + speedZ);

        isGround = false;
    }

    void Jump()
    {
		GameObject obj = Instantiate(Resources.Load("Prefab/Pulse") as GameObject, transform.position, transform.rotation);
		obj.transform.SetParent(transform);
		ParticleSystem newObjPaticle = obj.GetComponent<ParticleSystem>();
		var newShape = obj.GetComponent<ParticleSystem>().shape;
		newShape.skinnedMeshRenderer = GameObject.Find("Nazuna").GetComponent<SkinnedMeshRenderer>();
		var newLight = obj.GetComponent<ParticleSystem>().lights;
		newLight.light = GameObject.Find("Light").GetComponent<Light>();



		Destroy(obj, 0.5f);

        rigidbody.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision other_)
    {
        Debug.Log("sagiulsdahgi");
        if(other_.transform.tag == "Ground")
        {
            isGround = true;
        }
    }
}
