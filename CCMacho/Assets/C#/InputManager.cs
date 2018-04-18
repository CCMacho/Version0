using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    float speedY = 0f;
    float speedZ = 0f;
    [SerializeField]
    float addSpeedZ = 0.1f;
    [SerializeField]
    float maxSpeedZ = 2f;

    float jumpPower = 10f;
    Rigidbody rigidbody;
	[SerializeField]
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

        if (speedZ + addSpeedZ < maxSpeedZ)
        {
            speedZ += addSpeedZ;
        }


        transform.Translate(0f, 0f, speedZ * Time.deltaTime);

        isGround = false;
    }

    void Jump()
    {
		GameObject obj = Instantiate(Resources.Load("Prefab/Pulse") as GameObject, transform.position, transform.rotation);

		//obj.transform.SetParent(transform);
		obj.transform.position = transform.position;
		Debug.Log("Nome");

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
		switch (other_.transform.tag)
		{
			case "Ground":
				isGround = true;
				break;
			case "Box":
				speedZ = 0;
				break;
		}
            
    }

	public void IsGround(bool bool_)
	{
		isGround = bool_;
	}
}
