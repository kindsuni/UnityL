using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

   
    
    public Transform bulletSpawn;
    float Timer = 0;
    public float delay = 0.25f;
    int dir=1;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!Pause.pause)
        {
            Timer += Time.deltaTime;
        if (Timer > delay)
        {
            Shoot();
            Timer = 0;
        }

        }
	}

    void Shoot()
    {
        if (GameObject.Find("Player").GetComponent<PlayerMove>().facingRight)
            dir = 1;
        else
            dir = -1;
        Vector3 pos = new Vector3(bulletSpawn.position.x, bulletSpawn.position.y, -0.1f);

        GameObject newink = MemoryPool.memoryInstance.InkObjectPool.GetObject();
          //StartCoroutine("ReturnInk", newink);
        newink.transform.position = pos;
        SoundManager.soundInstance.InkSound();
        newink.GetComponent<Rigidbody>().velocity = newink.transform.right * 30*dir;
        
     
    }
  


}
