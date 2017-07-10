using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRaycastAll : MonoBehaviour {
    private float speed = 5.0f;
    public float RayRange = 8.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float amtMove = speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * amtMove);
        
        Debug.DrawRay(transform.position, transform.forward * RayRange, Color.red);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 8.0f);

        for(int i = 0; i<hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
