using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour {

    public static Bird gonyou;

    public float upforce = 200f;
    private bool isdead = false;
    public static bool Ready;
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject ReadyText;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        rb2d.isKinematic = true;
        Ready = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(isdead ==false)
        {
            isReady();
            if(Input.GetMouseButtonDown(0))
            {
                Ready = false;                              
                rb2d.isKinematic = false;
                anim.SetTrigger("Flap");
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upforce));
                if(Input.GetMouseButtonDown(0)&&Input.GetKey(KeyCode.Space))
                {
                    rb2d.AddForce(new Vector2(0, upforce+5f));
                }
                
            }
            if (transform.position.y > 5f)
            {
                
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0,-upforce*2f));
            }
        }
        
	}
    private void OnCollisionEnter2D(Collision2D other)

    {
        anim.SetTrigger("Die");
        isdead = true;
        GameController.Instance.BirdDied();
    }
    public void isReady()
    {
        anim.SetBool("Ready", Ready);
        if(Ready ==false)
        {
            ReadyText.SetActive(false);
        }
        
    }
}
