using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    /// /////////////
    private Vector3 PctouchStartPos;//タッチされた場所を保存する
    private Vector3 PctouchEndPos;//タッチが放された場所を保存する
    ////////////////


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
        PcCon();//PC用

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //Jump();
        }

        if (speedZ + addSpeedZ < maxSpeedZ)
        {
            speedZ += addSpeedZ;
        }


        transform.Translate(0f, 0f, speedZ * Time.deltaTime);

        isGround = false;
    }

    void PcCon()
    {
        //Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;

        //print(Input.touchCount);

        for (int i = 0; i < 1; i++)
        {
            //print("S");

            //タッチすると行う何かをここに記入
            if (Input.GetKeyDown(KeyCode.Mouse0)) //PCデバッグ用
            {
                PctouchStartPos = new Vector3(Input.mousePosition.x,
                                            Input.mousePosition.y,
                                            Input.mousePosition.z);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0)) //PCデバッグ用
            {

                PctouchEndPos = new Vector3(Input.mousePosition.x,
                                          Input.mousePosition.y,
                                          Input.mousePosition.z);
                PcGetDirection();

            }
        }
    }

    void PcGetDirection()
    {
        print("aaa");

        float directionX = PctouchEndPos.x - PctouchStartPos.x;
        float directionY = PctouchEndPos.y - PctouchStartPos.y;
        string Direction = null;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
        }


        switch (Direction)
        {
            case "up":
                Jump();
                print(Direction);
                //上フリックされた時の処理
                break;

            case "down":
                print(Direction);
                //下フリックされた時の処理
                break;

            case "right":
                print(Direction);
                //右フリックされた時の処理
                break;

            case "left":
                print(Direction);
                //左フリックされた時の処理
                break;

            case "touch":
                print(Direction);
                //タッチされた時の処理
                break;
        }
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
