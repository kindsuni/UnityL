using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour {

    public float initialVelocity;
    public float acceleration;
    float curvelocity;
    Rigidbody rb;
    float time;
	// Use this for initialization
	void Start () {
        curvelocity = initialVelocity; //초기속도를 저장
        rb = GetComponent<Rigidbody>();
	}
    private void FixedUpdate()
    {
       
        if(time<Timer.t)
        {
        rb.velocity = curvelocity * Vector3.right;
        curvelocity += acceleration*Time.fixedDeltaTime;     
        time += Time.deltaTime;
        print("Timer :" +time);
        }
        else
        {
            rb.velocity = Vector3.zero;
            curvelocity = 0f;
        }
    }
    
    // Update is called once per frame
    void Update () {
       
       
	}
}
