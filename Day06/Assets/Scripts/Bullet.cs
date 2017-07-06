using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private static readonly float bulletMoveSpeed = 10.0f;
    public GameObject hitEffectPrefab = null;
    Vector3 dir;
    Vector3 vecAddpos;
    Rigidbody bul;
    // Use this for initialization
    void Start () {
        dir = Vector3.zero;
        bul = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        Camera[] sub = Camera.allCameras;
      //  dir = transform.TransformDirection(sub[1].transform.forward);
        
        
        Vector3 vecAddPos = (dir * bulletMoveSpeed);
        bul.AddForce(vecAddPos);
        
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(null !=hitEffectPrefab)
        {
            Instantiate(hitEffectPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
