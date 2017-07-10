using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMainScript : MonoBehaviour {
    public Transform firePos;
    public GameObject cannon;
    public Transform spawnPoint;
    public GameObject myParticle;


    // Update is called once per frame
    void Update () {

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(cannon, firePos.position, firePos.rotation);          
        }
            
		
	}
    void Domyparticle()
    {
        GameObject particleObj = Instantiate(myParticle);
        particleObj.transform.position = spawnPoint.position;
        Destroy(particleObj, 2.0f);

    }

}
