using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class volumeChanged : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
      
        GameObject.Find("AudioSource").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
        Scrollbar ga = GetComponent<Scrollbar>();
        GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("volume");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void changedVolume()
    {
        GameObject.Find("AudioSource").GetComponent<AudioSource>().volume = GetComponent<Scrollbar>().value;
        PlayerPrefs.SetFloat("volume", GameObject.Find("AudioSource").GetComponent<AudioSource>().volume);
    }
}
