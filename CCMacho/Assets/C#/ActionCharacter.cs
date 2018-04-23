using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCharacter : MonoBehaviour {

	float speedY = 0f;
	float speedZ = 0f;
	[SerializeField]
	float addSpeedZ = 0.1f;
	[SerializeField]
	float maxSpeedZ = 2f;
	[SerializeField]
	float jumpPower = 10f;

	//当たり判定フラグ
	bool isGround = false;
	bool isHit = false;
	bool isHeadHeightBox = false;
	bool isLegHeightBox = false;

	Vector3 oldPosition = Vector3.zero;

	//シングルトン
	Rigidbody rigidbody = null;
	ParkourGameManager parkourGameManager = null;
	[SerializeField]
	Text hitText = null;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		parkourGameManager = FindObjectOfType<ParkourGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		oldPosition = transform.position;


		transform.Translate(0f, 0f, speedZ * Time.deltaTime);
		if (speedZ + addSpeedZ < maxSpeedZ && !isHit)
		{
			speedZ += addSpeedZ;
		}

		isHit = false;
		//isHeadHeightBox = false;

		//UI
		if (hitText != null)
		{
			hitText.text = "Head " + isHeadHeightBox.ToString() + " Leg " + isLegHeightBox.ToString();

		}

	}

	public void Jump()
	{
		if (!isGround)
		{
			return;
		}


		GameObject obj = Instantiate(Resources.Load("Prefab/Pulse") as GameObject, transform.position, transform.rotation);

		//obj.transform.SetParent(transform);
		obj.transform.position = transform.position;

		ParticleSystem newObjPaticle = obj.GetComponent<ParticleSystem>();
		var newShape = obj.GetComponent<ParticleSystem>().shape;

		newShape.skinnedMeshRenderer = GameObject.Find("Nazuna").GetComponent<SkinnedMeshRenderer>();

		var newLight = obj.GetComponent<ParticleSystem>().lights;

		newLight.light = GameObject.Find("Light").GetComponent<Light>();

		Destroy(obj, 0.5f);

		rigidbody.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);

		if (isHeadHeightBox)
		{
			parkourGameManager.CommandTimeOn();
		}
	}

	public void Sliding()
	{
		if (!isGround)
		{
			return;
		}



		GameObject obj = Instantiate(Resources.Load("Prefab/SlidingPulse") as GameObject, transform.position, transform.rotation);

		//obj.transform.SetParent(transform);
		obj.transform.position = transform.position;

		ParticleSystem newObjPaticle = obj.GetComponent<ParticleSystem>();
		var newShape = obj.GetComponent<ParticleSystem>().shape;

		newShape.skinnedMeshRenderer = GameObject.Find("Nazuna").GetComponent<SkinnedMeshRenderer>();

		var newLight = obj.GetComponent<ParticleSystem>().lights;

		newLight.light = GameObject.Find("Light").GetComponent<Light>();
		Destroy(obj, 0.5f);
		rigidbody.AddForce(new Vector3(0f, 0f, jumpPower), ForceMode.Impulse);

		if (isHeadHeightBox)
		{
			parkourGameManager.CommandTimeOn();
		}
	}

	public void SpeedZ(float num_)
	{
		speedZ = num_;
	}
	public void Hit()
	{
		speedZ = 0;
		isHit = true;

		transform.position = new Vector3(transform.position.x, transform.position.y, oldPosition.z);
	}

	public void IsGround(bool bool_)
	{
		isGround = bool_;
	}

	public void HeadHeightBox(bool bool_ = true)
	{
		isHeadHeightBox = bool_;
	}

	public void LegHeightBox(bool bool_ = true)
	{
		isLegHeightBox = bool_;
	}


}
