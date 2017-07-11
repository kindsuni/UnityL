using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContol : MonoBehaviour {

    public GameObject sword;
    public GameObject M4;
    bool weapon=true;  
	// Use this for initialization
	void Start () {
        sword.SetActive(weapon);
        M4.SetActive(!weapon);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void WeaponChangeBtnClicked()
    {
        if (!Pause.pause)
        {

            weapon = !weapon;
        sword.SetActive(weapon);
        M4.SetActive(!weapon);

        }
    }

}
