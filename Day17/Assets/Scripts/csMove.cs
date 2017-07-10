using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMove : MonoBehaviour {

    public float MoveSpeed = 5.0f;
    public float rotSpeed = 120.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float amtMove = MoveSpeed * Time.deltaTime;
        float rot = rotSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * ver * amtMove);
        transform.Rotate(Vector3.up * hor * rot);
	}
}
