using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {
   public Transform fruit;
    public Transform spawnpos1;
    public Transform spawnpos2;
    public int appleCount;
    float delayTime = 2f;
    float spawnPosition;
    float nextSpawnTime;
	// Use this for initialization
	void Start () {
        nextSpawnTime = Time.time + delayTime;
    }
	
	// Update is called once per frame
	void Update () {

        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + delayTime;
            SpawnApple();
        }
	}
    void SpawnApple()
    {
        for(int i = 0; i<=appleCount; i++)
        {
            spawnPosition = Random.Range(spawnpos1.transform.position.x, spawnpos2.transform.position.x);
           
            Vector3 spawn = new Vector3(spawnPosition, spawnpos1.transform.position.y, spawnpos1.transform.position.z);
            Instantiate(fruit, spawn , Quaternion.identity);
            //Instantiate(fruit, transform.position, Quaternion.identity);
           

        }
    }
}
