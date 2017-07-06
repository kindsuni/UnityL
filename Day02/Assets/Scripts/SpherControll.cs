using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.F))
            {
            GameObject go = GameObject.Find("Cube"); //큐브란 이름을 가진 오브젝트를 찾아
            go.GetComponent<CubeControll>().bigsize(); //큐브 안에 컴포넌트에 들어가있는 스크립트안에 메소드 bigsize를 불러옴.
        }
	}
}
