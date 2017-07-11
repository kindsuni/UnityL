using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	// 이 스크립트는 아무 오브젝트에다가 넣어도 적용됨

	private GameObject king;                            // 카메라 타겟
	private Vector3 offset = new Vector3(1, 15, -22);   // 카메라와 타겟간의 간격

	void FixedUpdate()
	{
		king = GameObject.FindGameObjectWithTag("King");

		// 카메라 위치를 타겟에서 정해둔 간격만큼 갱신
		Camera.main.transform.position = king.transform.position + offset;
	}
}
