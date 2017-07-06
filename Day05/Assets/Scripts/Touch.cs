using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
    Animator dm;

	// Use this for initialization
	void Start () {
        dm = GetComponent<Animator>();

		
	}
	
	// Update is called once per frame
	void Update () {
        dm.SetBool("HeadShot", false);
        dm.SetBool("BodyShot", false);

        Ray ray;
        RaycastHit hit;// ray캐스트에 부딪히는 변수
        GameObject hitobj;
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //카메라 관점에서 레이저를 쏨.
            if(Physics.Raycast(ray, out hit ,100)) //bool값으로 부딪히면 hit값을 out
            {
                hitobj = hit.collider.gameObject;

                if(hitobj.gameObject.tag =="Head")
                {
                    dm.SetBool("HeadShot", true);
                }
                if(hitobj.gameObject.tag == "Body")
                {
                    dm.SetBool("BodyShot", true);
                }
                
            }
        }
	}
}
