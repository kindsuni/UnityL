using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour {
    public Animator Anim;
    private float inputH;
    private float inputV;
    public Rigidbody rb;
    public bool run;
    private float Jumping = 100f;
    // Use this for initialization
    void Start () {
        print("log");// ==> Debug.Log();
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1"))
        {  //        애니메이션이름,레이어,딜레이시간.
            Anim.Play("SLIDE00", 0, 0f);
        }
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        
        Anim.SetFloat("inputH", inputH);
        Anim.SetFloat("inputV", inputV);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
            
        }
        else
        {
            run = false;
        }
        Anim.SetBool("Run", run);

        if(Input.GetKey(KeyCode.Space))
        {
            Anim.SetBool("Jump", true);
            
        }
        else
        {
            Anim.SetBool("Jump", false);
        }
        float MoveX = inputH * 20f * Time.deltaTime;
      
        float MoveZ = inputV * 50f * Time.deltaTime;

        if(MoveZ <0)
        {
            MoveZ = inputV * 10f * Time.deltaTime;
        }
        
        if(run)
        {
            MoveX *= 3f;
            MoveZ *= 3f;
        }
        rb.velocity = new Vector3(MoveX, 0, MoveZ);
    }
}
