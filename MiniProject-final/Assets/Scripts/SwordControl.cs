using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour {

    //public float rotSpeed=120.0f;
    //public int ang = 1;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // print(transform.rotation.y);
        //if (transform.rotation.y < 0.4f)
        //    ang = 1;
        //else if (transform.rotation.y > 0.9f)
        //    ang = -1;

        //    transform.Rotate(Vector3.up * rotSpeed * ang * Time.deltaTime);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<BossHpBar>().TakeDamage(10);

        }
        if (other.gameObject.tag == "Monster")
        {
            other.gameObject.GetComponent<MonsterHp>().TakeDamage(100);
        }
    }
}
