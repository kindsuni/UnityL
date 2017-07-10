using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 10.0F;

	static Animator anim; //스태틱 

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>(); //애니메이터 컴포넌트
		Cursor.lockState = CursorLockMode.Locked; //마우스 락
	}

	// Update is called once per frame
	void Update () {
        Move();

    }
    void Move()
    {
		float move_z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float move_x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		transform.Translate(move_x, 0, move_z);

		if (Input.GetButton ("Fire1")) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}

		if(move_z != 0)
		{
			anim.SetBool("isWalking",true);
			anim.SetBool("isIdle",false);
		}
		else
		{
			anim.SetBool("isWalking",false);
			anim.SetBool("isIdle",true);
		}

		if (Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;

	}
}

