using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;

	Vector3 movement;                   // 플레이어 이동 벡터
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 1000.0f;       // *길이를 충분히 길게 해주지 않으면 Floor랑 충돌검사를 못하는 경우가 생김
	Animator anim;

	void Start()
	{
		floorMask = LayerMask.GetMask("Floor");

		playerRigidbody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();

		Cursor.visible = false;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Move(h, v);

		// 바닥에 충분한 크기의 평평한 Collider를 두고 스크린에서
		// 마우스 포인터 위치방향으로 Ray를 계속 쏴서 경호원를 그 방향으로 회전시킴
		Turning();
	}

	void Move(float h, float v)
	{
		// 조금이라도 움직이면 걷는 모션
		if (h != 0.0f || v != 0.0f)
		{
			anim.SetBool("IsIdle", false);
			anim.SetBool("IsWalking", true);
		}
		else
		{
			anim.SetBool("IsIdle", true);
			anim.SetBool("IsWalking", false);
		}

		// Set the movement vector based on the axis input.
		movement.Set(h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * playerSpeed * Time.deltaTime;

		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다. normalized
		viewPos.x = Mathf.Clamp(viewPos.x, 0.035f, 0.965f);                     //x값을 두번째 파라미터 이상, 세번째 파라미터 이하로 제한한다.
		viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.85f);                       //y값을 두번째 파라미터 이상, 세번째 파라미터 이하로 제한한다.
		Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);           //다시 월드 좌표로 변환한다.
		worldPos.y = 0f;                                                        //캐릭터에 좌표를 적용하기 전에 y는 0으로 만들어준다.
		transform.position = worldPos;                                          //캐릭터에 좌표를 적용한다.

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition((transform.position + movement));
	}

	void Turning()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		//Debug.DrawRay(camRay.origin, camRay.direction * Camera.main.farClipPlane, Color.red, 5.0f);

		// Perform the raycast and if it hits something on the floor layer...
		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;

			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;

			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

			// 플레이어와 마우스위치간 방향을 구했으므로 
			playerRigidbody.MoveRotation(newRotation);
		}
	}

}
