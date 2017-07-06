using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPoo : MonoBehaviour {
    //오브젝트 풀링(5개 정도 생성해서 재사용).
    public GameObject columnPrefab;
    public int columnPoolsize = 5;//5개
    public float spawnRate = 3f; //3초 단위로 생성.
    public float columnMin = -3f;// Y포지션 최소값 범위
    public float columnMax = 2f; // 최대값 범위

    private GameObject[] columns; //배열에 지정해서 사용. 풀링할 배열
    private int currentColumn = 0; // 몇번째 것 쓸건지

    
    private Vector2 objectPoolPosition = new Vector2(-10, -25);
    private float spawnXPosition  = 10f;
    private float  timeSinceLastSpawned;
    // Use this for initialization  
    void Start () {

        timeSinceLastSpawned = 0f;
        columns = new GameObject[columnPoolsize];
        for(int i = 0; i<columnPoolsize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
       
        timeSinceLastSpawned += Time.deltaTime;
       
            if (GameController.Instance.gameOver == false && timeSinceLastSpawned >= spawnRate) //게임오버가 아니고 스폰 레이트보다 커지면 리스폰.
            {

                timeSinceLastSpawned = 0f; //먼저 클리어부터.
                float spawnYPosition = Random.Range(columnMin, columnMax); //Y포지션 랜덤으로.
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition); //현재 커럼에 있는 위치 값을 새로 포지션 바꿔서 생성.
                currentColumn++; //다음 오브젝트로 넘김.


                if (currentColumn >= columnPoolsize) //5보다 커지면 다시 배열 0으로 초기화            
                    currentColumn = 0;

            }
        
	}
}
