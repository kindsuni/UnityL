using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    public GameObject lookAt;
    bool smooth = true;
    
    public float smoothSpeed = 0.125f;
    private Vector3 offset;//= new Vector3(0, 14f, -20.0f); 

    
	// Use this for initialization
	void Start () {


        offset = new Vector3(0, transform.position.y - lookAt.transform.position.y, transform.position.z - lookAt.transform.position.z);
	}

    // Update is called once per frame
    private void LateUpdate()
    {

        Vector3 desiredPosition = lookAt.transform.position + offset;
        if (smooth && lookAt.GetComponent<PlayerMove>().facingRight&&lookAt.transform.position.x>=gameObject.transform.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        
        
    }
}
