using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    public GameObject Cam;
    public GameObject Obj;
    private Vector3 Offset;
	// Use this for initialization
	void Start () {
        Offset =Cam.transform.position - Obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Cam.transform.position = Offset + Obj.transform.position;
	}
}
