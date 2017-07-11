using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invoke3sec : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Image>().color = new Color(255, 255, 255, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("Active", 3.0f);
	}

    void Active()
    {
        this.GetComponent<Image>().color = new Color(255, 255, 255, 1);
    }
}
