using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeTimer : MonoBehaviour {
    //스크립트를 원하는 오브젝트를 추가하면 자동으로 디스트로이.
    public float fTimeLimit = 1f;
    private float m_fTimeLeft = 0f;

    private void Awake()// 스타트보다 먼저 호출되는 메소드.
    {
        m_fTimeLeft = fTimeLimit;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_fTimeLeft -=Time.deltaTime; //매프레임마다 감소
        if(m_fTimeLeft <0f) //0보다 작아지면
        { 
            Destroy(gameObject);//스크립트 바인딩된 오브젝트를 디스트로이

        }
	}
}
