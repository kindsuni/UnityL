using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {
    //Move
    public float movespeed = 5.0f;
    public float rotationSpeed = 150f;
    float vector;
    float horizontal;

    //Shoot
    float bulletSpeed = 20f;
    public GameObject Bullet;
   public  Transform bulletspown;

    //Animation
    Animator ani;

    //Jump
    Rigidbody sol;
    public float gravity = -9.8f;
   
    float v = 0f;
    float u = 0f;
    float s = 0.5f;
    float a = -20f;
    Transform original;
    bool jump;

    
	// Use this for initialization

	void Start () {
        ani = GetComponent<Animator>();
        sol = GetComponent<Rigidbody>();
        original = transform.transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        move();
        shoot();

	}

    void shoot()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
           var bullet =  Instantiate(Bullet, bulletspown.position, bulletspown.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            Destroy(bullet, 1f);

            ani.SetBool("Shoot", true);
        }
        else
            ani.SetBool("Shoot", false);


    }

    void move()
    {
       
     
        vector = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, vector * movespeed*Time.deltaTime);
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
        if(Input.GetButton("Vertical"))
        {
        ani.SetBool("Run", true);
        }
        else
        {
            ani.SetBool("Run", false);
        }

        if(Input.GetKeyDown(KeyCode.Space)&&jump)
        {
            jump = false;
            print("jump");
            transform.position = original.position;
            u = Mathf.Sqrt(v - 2 * a * s);
            sol.velocity = Vector3.up * u;
            
        }
        else if(transform.position.y < 0.1)
        {
            print("jumping");
            jump = true;
        }
        
    }
}
