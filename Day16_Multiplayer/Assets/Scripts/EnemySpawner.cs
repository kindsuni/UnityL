using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class EnemySpawner : NetworkBehaviour {
    public GameObject enemyPrefab; //적 프리팹
    public int numberOfEnemies; //적 숫자.

    public override void OnStartServer()
    {
        for(int i = 0; i<numberOfEnemies; i++) //적 숫자까지 i값 증가
        {
            var spawnPosition = new Vector3(Random.Range(-8f, 8f), 0f,Random.Range(-8f,8f)); //리스폰 위치랜덤 x랜덤,y는0,z랜덤
            var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f); //리스폰 회전값 x는0,y랜덤
            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation); // 적프리팹 생성.
            NetworkServer.Spawn(enemy); //서버가 클라언트한테 만들라고 보내는거임.
        }
    }
}
