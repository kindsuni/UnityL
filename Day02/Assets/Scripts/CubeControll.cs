using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {                                   //Time.deltaTime =(1/60) 1초 동안 60 프레임 을 나누는 것. 컴퓨터 마다 다르기 때문에 항상 곱해줄것.
            //transform.Translate(new Vector3(0.0f, 0.0f, 3.0f * Time.deltaTime));
            transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);  //forward = 0,0,1 (Z는 전진 방향이다.)
        }
        if(Input.GetKey(KeyCode.R))
        {
            transform.Rotate(new Vector3(360.0f * Time.deltaTime, 0.0f, 0.0f));
        }

	}
    public  void bigsize() //public으로 선언하면 유동적으로 스크립트간 연결.
    {
        transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
    }
}
