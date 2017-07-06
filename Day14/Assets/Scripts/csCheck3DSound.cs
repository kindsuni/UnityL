using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCheck3DSound : MonoBehaviour {
    float speed = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        v = v * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * v);

        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
        }
	}
}
