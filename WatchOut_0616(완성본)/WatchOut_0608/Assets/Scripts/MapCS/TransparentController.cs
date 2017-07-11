using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentController : MonoBehaviour {
	// 이 스크립트는 아무 오브젝트에 있어도 돌아감

	public Material transparentMaterial;					// Shader가 Transparent인 Material

	private int buildingMask;								// Layer가 Shootable인 정보 저장
	private float camRayLength;								// Ray 길이, 충분하지 않으면 투명화가 안됨
	private Ray[] camRay = new Ray[4];						// 카메라로 부터 쏠 Ray
	private RaycastHit[][] hits = new RaycastHit[4][];		// RayCast에 걸리는 모든 건물을 저장해둘 RaycastHit Array
	private Vector3[] temp = new Vector3[4];

	void Start()
	{
		buildingMask = LayerMask.GetMask("Shootable");
		// 카메라 끝까지 쏘기 위해 farClipPlane 이용
		camRayLength = Camera.main.farClipPlane;
	}

	void FixedUpdate()
	{
		temp[0] = new Vector3((Screen.width * 8.5f) / 15.0f, Screen.height / 2.0f, 0.0f);
		temp[1] = new Vector3((Screen.width * 6.5f) / 15.0f, Screen.height / 2.0f, 0.0f);
		temp[2] = new Vector3(Screen.width / 2.0f, (Screen.height * 8.0f) / 15.0f, 0.0f);
		temp[3] = new Vector3(Screen.width / 2.0f, (Screen.height * 7.0f) / 15.0f, 0.0f);

		for (int i = 0; i < camRay.Length; i++)
		{
			// 내가 보고 있는 화면의 중심으로부터 동서남북으로 조금 떨어진 곳(temp[0]~[3])에 Ray 4개를 쏨
			camRay[i] = Camera.main.ScreenPointToRay(temp[i]);
			// 디버그용 Ray
			Debug.DrawRay(camRay[i].origin, camRay[i].direction * Camera.main.farClipPlane, Color.red, 0.5f);
			
			// Ray가 뚫고 지나가는 모든 오브젝트들의 정보를 저장하고 투명화 시킬지 검사
			hits[i] = Physics.RaycastAll(camRay[i], camRayLength, buildingMask);
			TransparentList(hits[i]);
		}
	}

	private void TransparentList(RaycastHit[] hits)
	{
		for (int i = 0; i < hits.Length; i++)
		{
			// Layer가 Shootable이면서 Tag가 Building이라면 이 스크립트의 Inspector창에서 public으로 넣어놓은 반투명 material로 교체
			if (hits[i].collider.gameObject.CompareTag("Building"))
			{
				hits[i].collider.gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
				hits[i].collider.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.05f);
			}
		}
	}
}
