using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDead : MonoBehaviour {

    
    
    public Transform groundCheck;
    bool grounded = false;
    
	// Use this for initialization
	void Start ()
    {
        
	}
    void Update ()
    {

       
        if (!Pause.pause)
        {
            grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(grounded)
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        else
            gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }

    }
   
    
}
