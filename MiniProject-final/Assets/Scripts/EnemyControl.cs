using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyControl : MonoBehaviour {

    public GameObject target;
    private Rigidbody rb;
    NavMeshAgent agent;
    Animator anim;
    public GameObject burstEffect;
    int killScore = 100;
    bool IsDamaging=false;
    public bool isresurrection = false;
    //public bool follow = false;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!Pause.pause)
        {
            if (isresurrection && !anim.GetBool("isDead"))
            {
                agent.enabled = true;
                anim.SetBool("isWalk", true);
                agent.destination = target.transform.position;
                 
            }

            else if (Vector3.Distance(target.transform.position, transform.position) < 18.0f && !anim.GetBool("isDead"))
            {
                agent.enabled = true;
                anim.SetBool("isWalk", true);
                agent.destination = target.transform.position;
            }
            else
            {
                agent.enabled = false;
                anim.SetBool("isWalk", false);
            }

       
        

        }
        
	}
   
    
    private void OnTriggerEnter(Collider other)
    {
           
        if (other.tag == "Player" && !anim.GetBool("isDead"))
        {
            other.gameObject.SendMessage("TakeDamage", 1);
        }
    }
}
