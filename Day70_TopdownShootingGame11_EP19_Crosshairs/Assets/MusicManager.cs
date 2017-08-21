using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioClip mainTheme;
    public AudioClip menuTheme;

	// Use this for initialization
	void Start () {
        AudioManger.instance.PlayMusic(menuTheme, 2);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManger.instance.PlayMusic(mainTheme, 3);
        }
	}
}
