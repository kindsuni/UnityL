using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
    Transform Obj = null;
	// Use this for initialization
	void Start () {
        Obj = GameObject.Find("LookAtCube").transform;
	}
	
	// Update is called once per frame
	void Update () {
     //   transform.RotateAround(Vector3.zero, Vector3.up, 40 * Time.deltaTime);

        transform.RotateAround(Vector3.zero, Vector3.up, 40 * Time.deltaTime);
        transform.LookAt(Obj);
    }
}
