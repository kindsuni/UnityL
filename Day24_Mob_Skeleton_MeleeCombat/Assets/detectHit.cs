using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class detectHit : MonoBehaviour {

	public Slider healthbar;
	Animator anim;
	public string opponent;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();

	}

    
	void OnTriggerEnter(Collider other)//칼
	{
        //print(other);
        //		other.gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
        //칼이 
        if (other.gameObject.tag != opponent)
            return;
        
        if (!other.gameObject.GetComponentInParent<canDamage>().enableDamage)
            return;

        healthbar.value -= 20;
        
        anim.SetBool("isDamaged", true);

		if(healthbar.value <= 0)
			anim.SetBool("isDead",true);
        
        Invoke("offDamagedState", 0.25f);
        

        
	}
    void offDamagedState()
    {
        anim.SetBool("isDamaged", false);
    }
}
