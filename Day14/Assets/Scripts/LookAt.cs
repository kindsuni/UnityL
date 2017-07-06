using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    Transform Obj = null;
    float Speed = 10.0f;
	// Use this for initialization
	void Start () {
        Obj = GameObject.Find("Cube").transform;
	}
	
	// Update is called once per frame
	void Update () {
        

        transform.LookAt(Obj);
	}
}
