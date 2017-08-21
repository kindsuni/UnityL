using UnityEngine;
using System.Collections;

public class BreakUp : MonoBehaviour {

	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) //마우스클릭
		{
			RaycastHit hit; //레이저
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //메인카메라의 스크린 크기만큼의 범위에서 마우스 위치
			if(Physics.Raycast(ray, out hit, 1000.0f) && hit.collider.tag == "block")//쏜 레이저가 block에 맞으면
			{
				hit.collider.gameObject.GetComponent<BlockManager>().RegisterHit(); //블록메니저의 RegisterHit메소드를 부름.
			}
		}
	}
}
