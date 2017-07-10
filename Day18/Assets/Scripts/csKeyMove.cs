using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csKeyMove : MonoBehaviour {

    public float MoveForce = 100.0f;
	
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector3.zero;
        //Horizontal z방향
        transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Horizontal") * MoveForce* -1 * Time.deltaTime, Vector3.forward);

        //Vertical X방향
        transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Vertical") * MoveForce * -1 * Time.deltaTime, Vector3.left);
	}
}
