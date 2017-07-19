using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float moveSpeed = 3f;
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, 0);
        if (Input.GetButtonDown("Jump")) {
            transform.Rotate(Vector3.up*180f);
        }
    }
}
