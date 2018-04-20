//全ての処理の統括

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    string machoAPath = "Prefab/MachoA";
    string machoAMaterialPath = "Material/r255";


    int machoCount = 0;
    [SerializeField]
    int maxMachoCount = 200;
    GameObject machoA = null;
    GameObject[] machoAs;
    struct machosDataStruct {
        public bool returnNow;
        
    };

    machosDataStruct[] machosData;

    Vector2 stageRange = new Vector2(300f, 200f);

    GameObject[] ball;
    Text point;
    int[] points = { 0, 0 };

    enum MoveType{
        Stop,
        AllAuto,
        BOnlyAuto,
        BOnlyRondm,
    }

    [SerializeField]
    MoveType moveType;
	[SerializeField]
	float magnificationForce = 5f;


	// Use this for initialization
	void Start()
    {
        Application.targetFrameRate = 60;

        System.Array.Resize(ref machoAs, maxMachoCount);
        System.Array.Resize(ref machosData, maxMachoCount);


        machoA = Resources.Load(machoAPath) as GameObject;
        ball = GameObject.FindGameObjectsWithTag("Ball");
        point = GameObject.Find("Point").GetComponent<Text>();


        while (machoCount < maxMachoCount)
        {
            float xPosition = (float)(machoCount % 50) * 2f;
            float zPosition = (float)(machoCount / 50) * 2f;

            GameObject obj = (GameObject)Instantiate(machoA, new Vector3(xPosition, 0, zPosition), Quaternion.identity);

            if (machoCount < maxMachoCount / 2)
            {
                Material[] material = new Material[] { (Material)Resources.Load(machoAMaterialPath) as Material };
                obj.GetComponent<Renderer>().materials = material;
                obj.GetComponent<ParticleSystemRenderer>().material = material[0];

            }
            else
            {
                obj.transform.tag = "ManB";
            }

            machoAs[machoCount] = obj;
            ++machoCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveType)
        {
            case MoveType.Stop:

                break;

            case MoveType.AllAuto:

                for (int i = 0; i < machoAs.Length; ++i)
                {
                    Vector3 machoAForce = new Vector3(0, 0, 0);

                    if (i < maxMachoCount / 2)
                    {
                        machoAForce = TeamAutoMove(i, true);

                        //machoAForce.x += 1f;
                    }
                    else
                    {
                        machoAForce += TeamAutoMove(i, false);
                        //machoAForce.z -= 1f;
                    }

                    //machoAForce.x += Random.Range(-1f, 1f);
                    //machoAForce.z += Random.Range(-1f, 1f);

                    Rigidbody rigidbodyComponent = machoAs[i].GetComponent<Rigidbody>();

                    rigidbodyComponent.AddForce(machoAForce, ForceMode.Impulse);

                }
                break;

            case MoveType.BOnlyAuto:

                for (int i = 0; i < machoAs.Length; ++i)
                {
                    Vector3 machoAForce = new Vector3(0, 0, 0);

                    if (i < maxMachoCount / 2)
                    {
                    }
                    else
                    {
                        machoAForce += TeamAutoMove(i, false);
                        //machoAForce.z -= 1f;
                        Rigidbody rigidbodyComponent = machoAs[i].GetComponent<Rigidbody>();

                        rigidbodyComponent.AddForce(machoAForce, ForceMode.Impulse);
                    }

                }
                break;

            case MoveType.BOnlyRondm:

                for (int i = 0; i < machoAs.Length; ++i)
                {
                    Vector3 machoAForce = new Vector3(0, 0, 0);

                    if (i < maxMachoCount / 2)
                    {
                    }
                    else
                    {

                        machoAForce.x += Random.Range(-1f, 1f);
                        machoAForce.z += Random.Range(-1f, 1f);
                 
                        Rigidbody rigidbodyComponent = machoAs[i].GetComponent<Rigidbody>();

                        rigidbodyComponent.AddForce(machoAForce, ForceMode.Impulse);
                    }

                }
                break;
        }
    }

    Vector3 TeamAutoMove(int machoCount_, bool ATeam_)
    {
        Vector3 force = new Vector3(0f, 0f, 0f);
        float returnRenge = 0f;

        //帰る
        if (machosData[machoCount_].returnNow == true)
        {
            float teamChange = ATeam_ ? 1f : -1f;

            force += new Vector3(-1f * teamChange , 0f, 0f);

            if (machoAs[machoCount_].transform.position.x > stageRange.x / 2f  - 10f)
            {
                machosData[machoCount_].returnNow = false;
            }

            return force * magnificationForce;
        }

        //押す
        if (ATeam_)
        {
            if (ball[0].transform.position.x > machoAs[machoCount_].transform.position.x + returnRenge)
            {
                force += new Vector3(1f, 0f, 0f);
                if (ball[0].transform.position.z < machoAs[machoCount_].transform.position.z)
                {
                    force += new Vector3(0f, 0f, -1f);
                }
                else
                {
                    force += new Vector3(0f, 0f, 1f);
                }
            }
            else
            {   //押せる位置に下がる
                force += new Vector3(-0.5f, 0f, 0f);
                if (ball[0].transform.position.z < machoAs[machoCount_].transform.position.z)
                {
                    force += new Vector3(0f, 0f, 0.5f);
                }
                else
                {
                    force += new Vector3(0f, 0f, -0.5f);
                }
            }
        }
        else
        {
            if (ball[0].transform.position.x < machoAs[machoCount_].transform.position.x - returnRenge)
            {
                force += new Vector3(-0.5f, 0f, 0f);
                if (ball[0].transform.position.z < machoAs[machoCount_].transform.position.z)
                {
                    force += new Vector3(0f, 0f, -0.5f);

                }
                else
                {
                    force += new Vector3(0f, 0f, 0.5f);

                }
            }
            else
            {
                machosData[machoCount_].returnNow = true;
            }
        }

        return force *= magnificationForce;
    }

    public void AddRedPoint()
    {
        if(point != null)
        {
			point.text = (points[0] += 1).ToString().PadLeft(2, '0') + "-" + points[1].ToString().PadLeft(2, '0');
        }
    }

	public void AddBluePoint()
	{
		if (point != null)
		{
			point.text = points[0].ToString().PadLeft(2,'0')  + "-" + (points[1] += 1).ToString().PadLeft(2, '0');
		}
	}

	public float MagnificationForce()
	{
		return magnificationForce;
	}

}
