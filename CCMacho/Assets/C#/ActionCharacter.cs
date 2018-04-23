//アクションキャラクターの基本挙動
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
	[SerializeField]
	float slidingTime = 1f;
	float nowSlidingTime = 0f;

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
	GameObject bodyCollision;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		parkourGameManager = FindObjectOfType<ParkourGameManager>();
		bodyCollision = transform.Find("BodyCollision").gameObject;
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

		if (nowSlidingTime > 0f)
		{
			nowSlidingTime -= Time.deltaTime;
			if (nowSlidingTime <= 0)
			{
				bodyCollision.transform.localScale = new Vector3(bodyCollision.transform.localScale.x, bodyCollision.transform.localScale.y * 2f, bodyCollision.transform.localScale.z);
			}
		}
	}

	//ジャンプの挙動
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

	//スライディング挙動
	public void Sliding()
	{
		if (!isGround)
		{
			return;
		}

		bodyCollision.transform.localScale = new Vector3(bodyCollision.transform.localScale.x, bodyCollision.transform.localScale.y / 2f, bodyCollision.transform.localScale.z);
		nowSlidingTime = slidingTime;

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

	//Z軸のスピード設定
	public void SpeedZ(float num_)
	{
		speedZ = num_;
	}

	//壁などに当たった時の挙動
	public void Hit()
	{
		speedZ = 0;
		isHit = true;

		transform.position = new Vector3(transform.position.x, transform.position.y, oldPosition.z);
	}

	//接地情報の設定
	public void IsGround(bool bool_)
	{
		isGround = bool_;
	}

	//頭の高さに障害物があるかの設定
	public void HeadHeightBox(bool bool_ = true)
	{
		isHeadHeightBox = bool_;
	}

	//足の高さに障害物があるかの設定
	public void LegHeightBox(bool bool_ = true)
	{
		isLegHeightBox = bool_;
	}



}
