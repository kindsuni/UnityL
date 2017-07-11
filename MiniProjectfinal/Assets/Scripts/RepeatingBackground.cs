using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float groundHorizontalLenth;

    // Use this for initialization
    private void Awake()
    {
        //groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLenth = 20.48f;
            //groundCollider.size.x;
    }

    // Update is called once per frame
    void Update ()
    {
        print(transform.position.x);
        print(-groundHorizontalLenth);
        if (transform.position.x < -groundHorizontalLenth)
        {
           
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {
        Vector2 grondOffset = new Vector2(groundHorizontalLenth * 2f, 0);
        transform.position = (Vector2)transform.position + grondOffset;
    }

}
