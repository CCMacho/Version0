using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {

    private Vector3[] touchStartPos;//タッチされた場所を保存する
    private Vector3[] touchEndPos;//タッチが放された場所を保存する
    private Vector3 PctouchStartPos;//タッチされた場所を保存する
    private Vector3 PctouchEndPos;//タッチが放された場所を保存する


    void Start()
    {

    }

    void Update()
    {
        //PcCon();//PC用
        TouchCon();//タッチパネル用
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
                print("aaa");
                PcGetDirection();
                
            }
        }
    }

    void TouchCon()
    {
        Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;

        //print(Input.touchCount);

        for (int i = 0; i < Input.touchCount; i++)
        {
            //print("S");

            //タッチすると行う何かをここに記入
            //if (Input.GetKeyDown(KeyCode.Mouse0)) //PCデバッグ用
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                print("T");
                touchStartPos[i] = new Vector3(Input.mousePosition.x,
                                            Input.mousePosition.y,
                                            Input.mousePosition.z);
            }

            //if (Input.GetKeyUp(KeyCode.Mouse0)) //PCデバッグ用
            if (Input.touches[i].phase == TouchPhase.Ended)
            {
                touchEndPos[i] = new Vector3(Input.mousePosition.x,
                                          Input.mousePosition.y,
                                          Input.mousePosition.z);
                GetDirection(i);
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
    void GetDirection(int i)
    {
        float directionX = touchEndPos[i].x - touchStartPos[i].x;
        float directionY = touchEndPos[i].y - touchStartPos[i].y;
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

}
