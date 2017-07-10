using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	Transform original;
	Rigidbody rb;
	PhysicData data;

	float v = 0;
	float a = -20f;
	float s = 3f;
	float g = -9.8f;
    bool Simul;
	// Use this for initialization
	void Start () {
		data = GameObject.Find ("PhysicData").GetComponent<PhysicData> ();
		rb = GetComponent<Rigidbody> ();
		original = transform.transform;
	}
		
	void FixedUpdate() {
		if (Input.GetButtonDown("Jump")) {

			transform.position = original.position; 

			v = data.v;
			a = data.a;
			s = data.s;
			g = data.g;
                              //막속 -2 *가속도*거리 =초기속도.
			float u = Mathf.Sqrt(v - 2 * a * s);
            rb.velocity = Vector3.up * u;
           
		}
        
		rb.AddForce(Vector3.up * a);
            
                
        
		if (transform.position.y >= 1)
			print (transform.position.y);
	}

}
