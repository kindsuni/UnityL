using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour {
    GameObject cameraParent; //부모 카메라 지정.(메인카메라를 부모 카메라(빈오브젝트)에 자식으로 둠.

    Vector3 defaultPosition; //포지션 초기화용 변수
    Quaternion defaultRotaion; //로테이션 초기화용 변수
    float defaultZoom; //줌 초기화용 변수
	// Use this for initialization
	void Start () {
        cameraParent = GameObject.Find("CameraParent"); // 빈오브젝트로 만든 카메라 부모를 찾음.

        defaultPosition = Camera.main.transform.position; //초기값 저장.
        defaultRotaion = cameraParent.transform.rotation;
        defaultZoom = Camera.main.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) //마우스 왼쪽 버튼 누른채로 움직이면 x,y방향으로 메인 카메라가 움직임.
        {
            Camera.main.transform.Translate(-Input.GetAxisRaw("Mouse X") / 10, -Input.GetAxisRaw("Mouse Y") / 10 , 0);
        }
       if(Input.GetMouseButton(1)) //마우스 오른쪽 버튼 누른채로 움직이면 부모 카메라 기준으로 로테이션 됨.
        {
            //    Camera.main.transform.Rotate(-Input.GetAxisRaw("Mouse Y") * 10,Input.GetAxisRaw("Mouse X") * 10, 0);
            cameraParent.transform.Rotate(-Input.GetAxisRaw("Mouse Y") * 10, Input.GetAxisRaw("Mouse X") * 10, 0);
        }
        Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel")); //스크롤 하면 줌.

        if(Camera.main.fieldOfView <10)//줌이 10이하로 떨어지면 10으로 고정.
        {
            Camera.main.fieldOfView = 10;
           
        }
        if (Camera.main.fieldOfView > 60)//줌이 60이상으로 올라가면 60으로 고정.
        {
            Camera.main.fieldOfView = 60;
        }
        if (Input.GetMouseButton(2)) //휠버튼 누르면 초기 카메라 상태로 초기화.
        {
            Camera.main.transform.position = defaultPosition; //초기 XY포지션
            cameraParent.transform.rotation = defaultRotaion; //초기 로테이션 
            Camera.main.fieldOfView = defaultZoom; //초기 줌
        }
       

    }
}
