using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {
    private GameObject rubber;
	// Use this for initialization
	void Start () {
        rubber = GameObject.Find("RubberGlove");
        rubber.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedItem")
        {
            Destroy(other.gameObject);
            StartCoroutine("Speed");


        }
        if (other.gameObject.tag == "UnbeatableItem")
        {
            Destroy(other.gameObject);
            StartCoroutine("Unbeatable");
        }
    }
    IEnumerator Speed()
    {
        //
        SoundManager.soundInstance.Piber();
        GetComponent<PlayerMove>().speed = 10;
        yield return new WaitForSeconds(3f);
        GetComponent<PlayerMove>().speed = 0;
    }

    IEnumerator Unbeatable()
    {
        GetComponent<PlayerHPbar>().unbeatable = true;
        rubber.SetActive(true);
        yield return new WaitForSeconds(5f);
        GetComponent<PlayerHPbar>().unbeatable = false;
        rubber.SetActive(false);
    }
}
