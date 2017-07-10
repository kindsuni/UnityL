using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour {

    // Use this for initialization
    private IEnumerator Start()
    {
        Debug.Log(gameObject.name + " : 1");
        yield return null;
        Debug.Log(gameObject.name + " : 2");
        Debug.Log(gameObject.name + " : 3");

    }
    // Update is called once per frame
    void Update () {
		
	}
}
