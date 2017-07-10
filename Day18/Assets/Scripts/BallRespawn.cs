using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= -5.0f)
        {
           transform.position = Vector3.zero;
        }
	}
}
