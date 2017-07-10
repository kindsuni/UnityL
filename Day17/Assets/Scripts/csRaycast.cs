using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRaycast : MonoBehaviour {
    private float speed = 5.0f;
   public  float RayRange = 8f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float amtMove = speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * amtMove);
        //레이져 눈으로 보임.
        Debug.DrawRay(transform.position, transform.forward * RayRange, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,8))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
	}
}
