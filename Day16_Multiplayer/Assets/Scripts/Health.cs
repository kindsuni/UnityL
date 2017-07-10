using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //네트워크 사용
                     //모노를 상위로 받아서 네트워크를 사용
public class Health : NetworkBehaviour {
    
    public const int maxHealth = 100;
    public bool destroyOnDeath;
    [SyncVar(hook ="OnchangeHealth")] //서버로 피 관리 하게 해줌. hook은 값이 변하면 "메소드"를 호출.(서버,클라이언트 둘다 이루어짐)
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    private NetworkStartPosition[] spawnPoints;

    private void Start()
    {
        if(isLocalPlayer)
        
            spawnPoints = FindObjectsOfType<NetworkStartPosition>(); //객체들을 구함.
        
    }
    public void TakeDemage(int amount)
    {
        if(!isServer&& !isClient) 
        {
            return;
        } 
        //서버만 실행함.
        currentHealth -= amount;
        print("CurrentHealth: " + currentHealth);
        if(currentHealth <=0) //피가 0보다 작아지면
        {
            if(destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth; //피 초기화
                print("Dead!");

                RpcRespawn();
            }
           

        }
        
    }
    [ClientRpc] //안붙이면 호스트만 되어버림.
    void RpcRespawn()
    {
        if(isLocalPlayer) //자기 플레이어만 실행. 없으면 자기자신은 움직인것처럼 보이지만 다른사람한테는 그렇지 않게 보임.
        {
            Vector3 spawnPoint = Vector3.zero; //위치 초기화

            if (spawnPoints !=null && spawnPoints.Length >0) //있으면
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position; //위치값 받아서 리스폰.
            }
            transform.position = spawnPoint;//없으면
        }
    }
    void OnchangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
