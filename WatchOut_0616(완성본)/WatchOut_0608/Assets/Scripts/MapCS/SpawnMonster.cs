using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public Transform kingSpawn;
    public GameObject king;
    public GameObject player;

    public Transform[] monsterSpawns;
    public Transform[] monsterCSpawn;
    public GameObject[] monster;

    // Use this for initialization
    void Awake()
    {
        Spawn();
    }

    void Spawn()
    {
        string wayName = this.gameObject.name;
        switch (wayName)
        {
            case "Way1-1(Clone)":   //15 11 4 0
            case "Way1-2(Clone)":
                SpawnWay(5, 11, 4, 0);
                break;
            case "Way2-1(Clone)":   //14 8 5 1
            case "Way2-2(Clone)":
            case "Way2-3(Clone)":
                SpawnWay(4, 8, 5, 1);
                break;
            case "Way3-1(Clone)":   //16 6 10 3
            case "Way3-2(Clone)":
            case "Way3-3(Clone)":
                SpawnWay(3, 3, 10, 3);
                break;
            default:
                break;
        }
    }

    void SpawnWay(int FirA, int monA, int monB, int monC)
    {
        float range = Random.Range(-3.0f, 3.0f);

		// 캐릭터 배치
        Instantiate(king, kingSpawn.position, Quaternion.identity);
        Instantiate(player, kingSpawn.position + new Vector3(range, 0.0f, range), Quaternion.identity);

        int countMonsterA = 0;  //1&2&3
        int countMonsterB = 0;  //1&2&3

        //몬스터C 배치
        for (int i = 0; i < monC; i++)
        {
            Instantiate(monster[2], monsterCSpawn[i].position, Quaternion.identity);
        }

        //몬스터A 우선 배치
        for (int i = 0; i < FirA; i++)
        {
            Instantiate(monster[0], monsterSpawns[i].position, Quaternion.identity);
            countMonsterA++;
        }

        //몬스터A+B 랜덤 배치
        for (int i = FirA; i < monsterSpawns.Length; i++)
        {
            int monNum = Random.Range(0, 3); //0 1 2 : 1/3 확률로 B 소환

            if (countMonsterA > monA - 1)
            {
                Instantiate(monster[1], monsterSpawns[i].position, Quaternion.identity);
                countMonsterB++;
            }
            else
            {
                if (countMonsterB < monB)
                {
                    if (monNum == 0)
                    {
                        Instantiate(monster[1], monsterSpawns[i].position, Quaternion.identity);
                        countMonsterB++;
                    }
                    else
                    {
                        Instantiate(monster[0], monsterSpawns[i].position, Quaternion.identity);
                        countMonsterA++;
                    }
                }
                else
                {
                    Instantiate(monster[0], monsterSpawns[i].position, Quaternion.identity);
                    countMonsterA++;
                }
            }
        }
        //print(countMonsterA + "  " + countMonsterB);
    }
}
