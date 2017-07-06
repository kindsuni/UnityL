using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float ballinitialVelocity = 600f;

    private Rigidbody rb;
    private bool ballInPlay; //공이 플레이중인지.

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && ballInPlay ==false)
        {
            transform.parent = null; //공의 부모를 끊음.
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballinitialVelocity, ballinitialVelocity, 0));
        }
	}
}
