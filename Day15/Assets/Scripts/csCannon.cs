using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCannon : MonoBehaviour {
    float power = 900.0f;
    Vector3 velocity = new Vector3(0f, 0.3f, 0.5f);
	// Use this for initialization
	void Start () {
        velocity = velocity * power;

        GetComponent<Rigidbody>().AddForce(velocity);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if(this.transform.position.z>10.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
