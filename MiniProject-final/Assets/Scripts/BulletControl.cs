using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
          
            other.gameObject.GetComponent<BossHpBar>().TakeDamage(10);
            
            MemoryPool.memoryInstance.InkObjectPool.ReturnObject(gameObject);
            //Destroy(gameObject);
        }
        if (other.gameObject.tag == "Monster" && !other.gameObject.GetComponent<Animator>().GetBool("isDead"))
        {
           
            other.gameObject.GetComponent<MonsterHp>().TakeDamage(50);
          
            MemoryPool.memoryInstance.InkObjectPool.ReturnObject(gameObject);
            //Destroy(gameObject);
        }
        if (other.gameObject.tag == "Monster2" && !other.gameObject.GetComponent<Animator>().GetBool("isDead"))
        {

            other.gameObject.GetComponent<MonsterHp>().TakeDamage(50);

            MemoryPool.memoryInstance.InkObjectPool.ReturnObject(gameObject);
            //Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            MemoryPool.memoryInstance.InkObjectPool.ReturnObject(gameObject);
        }
        
    }
}
