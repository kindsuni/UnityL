using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour
{
    float curVelocity = 0f; //벨로시티 계산
	float curPosition = 0f; //포지션 계산
	float u; //초기속도.

	bool isSimulating = false; //시뮬레이팅
	Transform original; //초기 포지션.

	PhysicData data;

	float v = 0;
	float a = -20f;
	float s = 3f;
	float g = -9.8f;


	// Use this for initialization
	void Start () {
		data = GameObject.Find ("PhysicData").GetComponent<PhysicData> ();
		original = transform.transform;
	}

    void FixedUpdate()
    {
		if (Input.GetButtonDown("Jump") && !isSimulating) //점프를 한번 누르고나서 작동 정지.
        {
			v = data.v; //physic 스크립트의 데이터 가져옴.
			a = data.a;
			s = data.s;
			g = data.g;

			u = Mathf.Sqrt(v - 2 * a * s); //초기속도 계산.
			curVelocity = u; //벨로시티값으로 저장.
			curPosition = original.position.y; //위치벡터.
			print(u); 

			isSimulating = true;
        }

		if (isSimulating) { 
			curVelocity += a * Time.fixedDeltaTime; //초기속도에 가속도를 더해줌.
			curPosition += curVelocity * Time.fixedDeltaTime; //y방향으로 그 값의 힘을 가함.
			transform.position = new Vector3(transform.position.x, curPosition, transform.position.z); //실제로 위치가 바뀜.
		}

		if (isSimulating && transform.position.y < 0.1) {
			isSimulating = false;
            
			transform.position = original.position;
            
		}

    }

}
