using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject player;
    public GameObject enemy; //Prefab을 받을 public 변수 입니다.
    public Transform l_Point;
    public Transform r_Point;
    Vector3 dir;

    void Start()
    {
       
        InvokeRepeating("SpawnEnemy", 3, 3); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
    }
   
    void SpawnEnemy()
    {
        int a = Random.Range(0, 2);
            if (a == 0) { 
                GameObject enemy_right = (GameObject)Instantiate(enemy, r_Point.position, enemy.transform.rotation); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
                enemy_right.transform.LookAt(l_Point);
            }
            else if (a == 1) {
                GameObject enemy_left = (GameObject)Instantiate(enemy, l_Point.position, enemy.transform.rotation); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
                enemy_left.transform.LookAt(r_Point);            
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            other.gameObject.transform.TransformDirection(Vector3.forward*-1f);
        } 
    }
}
