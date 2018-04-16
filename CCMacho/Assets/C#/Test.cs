using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    //生成するオブジェクト
    public GameObject obj;
    public GameObject AriivePoint;

    //生成したオブジェクト
	GameObject createdObj;
	GameObject ArrivedObj;

    //大きくする大きさ
	[SerializeField]
	float OpenSpeed;

    void Start()
    {

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        //左クリックした場合
        if (Input.GetMouseButtonDown(0))
        {
               //レイを投げて何かのオブジェクトに当たった場合
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(createdObj);
                if (createdObj != null)
                {
                    ArrivedObj = Instantiate(AriivePoint, new Vector3(hit.point.x, 3f, hit.point.z), Quaternion.identity) as GameObject;

                }
                else
                {
                    Destroy(ArrivedObj);
                    //print(hit.point);
                    //レイが当たった位置(hit.point)にオブジェクトを生成する
                    createdObj = Instantiate(obj, new Vector3(hit.point.x, 3f, hit.point.z), Quaternion.identity) as GameObject;
                }
            }
        }

        if(Input.GetMouseButton(0))
        {
            if (createdObj != null)
            {
                Vector3 pos = createdObj.transform.localScale;
                pos.x += OpenSpeed;
                pos.z += OpenSpeed;
                createdObj.transform.localScale = pos;
            }
        }
    }

   
}
