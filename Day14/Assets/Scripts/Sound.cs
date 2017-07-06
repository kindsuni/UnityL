using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    private AudioSource MyAudio;
    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        print("Soundy");
        Destroy(this.gameObject,MyAudio.clip.length);
    }
}
