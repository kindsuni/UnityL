using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour {
    public GameObject select;
    public GameObject island;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (StartOption.playbuttonclick == true)
        {
            select.SetActive(false);
            island.SetActive(false);
            StartOption.playbuttonclick = false;
        }
	}
}
