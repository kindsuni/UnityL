using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStart : MonoBehaviour {
    public GameObject ready;
    public GameObject start;
    private void Awake()
    {
        off();
    }
    // Use this for initialization
    void Start () {
        _ready();
	}
	void _ready()
    {
        ready.SetActive(true);
        start.SetActive(false);
        Pause.pause = true;
        Invoke("_start", 2f);
    }
    void _start()
    {
        Pause.pause = false;
        ready.SetActive(false);
        start.SetActive(true);
        Invoke("off", 1f);
    }
    void off()
    {
        ready.SetActive(false);
        start.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
