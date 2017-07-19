using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
  public GameObject Ice;
    Rigidbody Rb;
    ArrayList ObjArray = new ArrayList();

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!Pause.pause)
        {

		if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Ice);
            ObjArray.Add(Ice);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(Ice);
        }
        }
	}
}
