using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Controllbutton : MonoBehaviour {
   public  Image con;
    bool active = true;
	// Use this for initialization
	void Start () {
        con.gameObject.SetActive(false);
    }
public 	void click()
    {
        con.gameObject.SetActive(active);
        active = !active;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
