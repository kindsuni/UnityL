using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {
    public float fallDelay = 0f;
    float timer = 0f;
    bool timerCheck = false;
    float timerMax = 1f;

    Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if(timerCheck)
        {
            timer += Time.deltaTime;
            print("Fall Timer" + timer);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
       
        
        if(other.gameObject.CompareTag("Player"))
        {
           
            timerCheck = true;
            if (timer >= timerMax)
            {
                Fall();
            }
        }
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
        timerCheck = false;
        if(!timerCheck)
        {
            timer = 0;
            rb2d.isKinematic = true;
        }
    }
    void Fall()
    {
        rb2d.isKinematic = false;
    }
    
}
