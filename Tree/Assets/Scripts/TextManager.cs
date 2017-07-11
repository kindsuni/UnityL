using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {
    public GameObject energy;
	// Use this for initialization
	void Start () {
        TreeController en;
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
        energy.GetComponent<Text>().text ="Energy : "+ TreeController.energy +"";
	}
}
