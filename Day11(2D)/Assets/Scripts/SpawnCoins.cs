using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {
    public Transform[] coinSpawns;
    public GameObject coin;

    public float DelayForEachCoin = 1f;
	// Use this for initialization
	void Start () {
        Spawn();	
	}
	
	void Spawn()
    {
        int Coins = 0;
        for(int i= 0; i<coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if(coinFlip >0)
            {
                Instantiate(coin, coinSpawns[i].position, Quaternion.identity);
                Coins++;
            }

        }
       gameObject.GetComponent<PlatformFall>().fallDelay = Coins * DelayForEachCoin;
    }
}
