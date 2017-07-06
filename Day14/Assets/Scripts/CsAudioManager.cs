using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsAudioManager : MonoBehaviour {
    public AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance().PlaySfx(clip);

        Destroy(this.gameObject);
    }
   
}
