using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour {
    private GameObject target;
	// Use this for initialization
	void Start () {
		
	}
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            castRay();
        }
    }
    void castRay()
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if(hit.collider != null)
        {
            print(hit.collider.name);
            target = hit.collider.gameObject;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
