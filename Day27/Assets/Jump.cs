using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    Rigidbody rb;
   

	// Use this for initialization
	void Start () {
  
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
                                    //    Physics.gravity.y ->-20f값
        { //     초기속도  =마지막속도 -2 * 가속도 *거리;
            float u = Mathf.Sqrt();
            rb.velocity = Vector3.up * u;
        }
        
        
	}
}
