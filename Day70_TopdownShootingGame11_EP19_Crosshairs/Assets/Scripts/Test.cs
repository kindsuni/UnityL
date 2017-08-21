using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Example ();	
	}
	
	// Update is called once per frame
	void Update () {
		// http://answers.unity3d.com/questions/150347/what-exactly-does-timetime-do-in-mathfpingpong.html
		print ("t = "+ Time.time + ", " + Mathf.PingPong (Time.time, 3));
	}

	void Example() {
        // If the number ends in .5 so it is halfway between two integers, 
        // one of which is even and the other odd, the even number is returned.
		Debug.Log(Mathf.RoundToInt(10.0F));
		Debug.Log(Mathf.RoundToInt(10.2F));
		Debug.Log(Mathf.RoundToInt(10.7F));
		Debug.Log(Mathf.RoundToInt(10.5F));		// 10
		Debug.Log(Mathf.RoundToInt(11.5F));		// 12
		Debug.Log(Mathf.RoundToInt(-10.0F));
		Debug.Log(Mathf.RoundToInt(-10.2F));
		Debug.Log(Mathf.RoundToInt(-10.7F));
		Debug.Log(Mathf.RoundToInt(-10.5F));	// -10
		Debug.Log(Mathf.RoundToInt(-11.5F));	// -12
	}
}
