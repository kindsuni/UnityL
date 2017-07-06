using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {

    public int maxPlatforms = 20;//플랫폼 개수
    public GameObject platform; //오브젝트
    public float horizontalMin = 7.5f; //좌우 민값
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;

    private Vector2 originPosition;

    // Use this for initialization
    void Start () {
        originPosition = transform.position; //시작 위치 지정.
        Spawn(); //스폰 메소드(스타트 하면 바로실행)
	}
	void Spawn()
    {
        for(int i = 0; i<maxPlatforms; i++) //맥스 플랫폼까지.
        { //처음 위치 + 랜덤 호리존탈, 랜덤 민값
            Vector2 randomposition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomposition, Quaternion.identity); //만들어짐.
            originPosition = randomposition;//만들어진 곳에서 랜덤으로 생성되야함.
        }
    }
	
}
