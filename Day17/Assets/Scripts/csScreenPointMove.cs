using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csScreenPointMove : MonoBehaviour {

    private bool Moving = false;
    Vector3 newpos;

    // Update is called once per frame
    void Update () {
		if(Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                 newpos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Moving = true;
            }

        }
        if(Moving)
        {
            Vector3 dir = newpos - transform.position;
            transform.Translate(dir.normalized * 4 * Time.deltaTime);
            
        }
        if(Vector3.Distance(newpos,transform.position)<0.1f)
        {
            Moving = false;
        }
	}
}
