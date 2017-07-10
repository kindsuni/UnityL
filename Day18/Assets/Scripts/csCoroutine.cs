using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCoroutine : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Exam1");
            //StartCoroutine(Exam1(10));
        }
	}
    //IEnumerator Exam1(int i)
    IEnumerator Exam1()
    { // 이번 렌더링이 끝난후 실행하고자 할때
        yield return new WaitForEndOfFrame();

        //실행 하고자하는 메소드나 코드
        FirstCall();

        //지정한 시간이 지난 후 실행 하고자 할 때
        yield return new WaitForSeconds(2.0f);

        //실행하고자 하는 함수나 코드
        SecondCall();
    }
    void FirstCall()
    {
        Debug.Log("First");

    }
    void SecondCall()
    {
        Debug.Log("Second");
    }
}
