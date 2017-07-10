using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    GameObject move;
    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

         transform.Translate(0, 0 , v);

	}
}
