using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour {

    public bool stanbyMove = false;

    float speed = 50f;
    private float rad;

    Vector3  nextMove;
    bool readyMove = false;

    float allowableDistance = 5f;

    Rigidbody rigidbody = null;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
		speed = FindObjectOfType<GameManager>().MagnificationForce();
	}
	
	// Update is called once per frame
	void Update () {
        if (readyMove == true) 
        {
            Move();

            if ((transform.position.x < nextMove.x + allowableDistance && transform.position.x > nextMove.x - allowableDistance) && (transform.position.z < nextMove.z + allowableDistance && transform.position.z > nextMove.z - allowableDistance)){

                readyMove = false;
                rigidbody.velocity = Vector3.zero;
            }
        }
    }

    void Move()
    {
       // rigidbody.velocity = Vector3.zero;

        rad = Mathf.Atan2(
             nextMove.z - transform.position.z,
              nextMove.x - transform.position.x);

        Vector3 Position = Vector3.zero;
        // これで特定の方向へ向かって進んでいく。
        Position.x += speed * Mathf.Cos(rad);
        Position.z += speed * Mathf.Sin(rad);
        // 現在の位置に加算減算を行ったPositionを代入する
        //rigidbody.AddForce(Position, ForceMode.Impulse);
        //rigidbody.velocity = Position;
        rigidbody.AddForceAtPosition(Position, nextMove, ForceMode.Impulse);

        //Debug.Log(rigidbody.velocity);
    }

    public void StanbyMove()
    {
        stanbyMove = true;
    }

    public void NextMove(GameObject move)
    {
        if (stanbyMove == true)
        {
            nextMove = move.transform.position;
            stanbyMove = false;
            readyMove = true;

            rigidbody.velocity = Vector3.zero;


        }
    }
}
