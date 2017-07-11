using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingRoam : MonoBehaviour
{
    public GameObject[] rom;
    public static Animator anim;

    private int i = 0;

    public static bool isGoal = false;

	GameObject[] mobA, mobB, mobC;

	// Use this for initialization
	void Start()
    {
        anim = GetComponent<Animator>();

        rom = GameObject.FindGameObjectsWithTag("KingPoint");

        Array.Sort(rom, delegate (GameObject user1, GameObject user2) {
            return user1.name.CompareTo(user2.name);
        });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameControl.isFail)
            return;

        isGoal = false;
        if (i == rom.Length)		//도착
        {
            Camera.main.transform.position =
                    Vector3.Lerp(rom[i - 2].transform.position + new Vector3(1, 15, -22),
                                rom[i - 1].transform.position + new Vector3(1, 15, -22), Time.fixedDeltaTime * 0.05f);

            isGoal = true;
            
            i = 0;

			NotPermittedDamage();
		}
        else
        {
			Vector3 dirR = rom[i].transform.position - transform.position;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(dirR, Vector3.up),
                0.1f);

            transform.Translate(0, 0, 0.08f);		// King Speed! , 0.08f 가 초기값


            if (dirR.magnitude < 2.5f)		// 0.05f 가 초기값, 다음 Roaming Point로 넘어가는 거리 기준이 너무 작으면 잘 안되므로 테스트 하면서 크게 조절할것
			{
                i++;
            }

            if (i == rom.Length - 1)		//도착 전 카메라 정지
			{
				Camera.main.transform.position =
					Vector3.Lerp(rom[i-1].transform.position + new Vector3(1, 15, -22),
								rom[i].transform.position + new Vector3(1, 15, -22), Time.fixedDeltaTime * 0.05f);
			}
        }
    }

	// 왕과 경호원의 충돌 이상 현상 방지
	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
			GetComponent<CapsuleCollider>().isTrigger = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			GetComponent<CapsuleCollider>().isTrigger = false;
	}

	// 왕이 매 스테이지 목적지에 도착시 모든 몹 제거
	void NotPermittedDamage()
	{
		mobA = GameObject.FindGameObjectsWithTag("MobA");
		mobB = GameObject.FindGameObjectsWithTag("MobB");
		mobC = GameObject.FindGameObjectsWithTag("MobC");

		for (int i = 0; i < mobA.Length; i++)
			Destroy(mobA[i].gameObject);

		for (int i = 0; i < mobB.Length; i++)
			Destroy(mobB[i].gameObject);

		for (int i = 0; i < mobC.Length; i++)
			Destroy(mobC[i].gameObject);
	}
}
