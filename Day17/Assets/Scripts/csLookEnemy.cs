using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLookEnemy : MonoBehaviour {

    public Transform enemy;
    private Transform spPoint;
    private Transform viewer;

    RaycastHit hit;
    Vector3 fwd = Vector3.forward;

	// Use this for initialization
	void Start () {
        spPoint = transform.Find("/Turret/Tower/SpawnPoint");
        viewer = transform.Find("/Turret/viewer");
	}
	
	// Update is called once per frame
	void Update () {

        //transform.LookAt(enemy);
        viewer.LookAt(enemy);
        transform.rotation = viewer.rotation;

        Vector3 newSpPoint = new Vector3(spPoint.position.x, viewer.transform.position.y, spPoint.position.z);


        //Debug.DrawRay(spPoint.position, spPoint.forward * 4, Color.red);
        Debug.DrawRay(newSpPoint, spPoint.forward * 4, Color.red);
        fwd = transform.TransformDirection(viewer.transform.forward);


        if(Physics.Raycast(spPoint.position,fwd,out hit, 4))
        {
            Debug.Log(hit.collider.gameObject);
        }
	}
}
