using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
    private BoxCollider2D groundCollider; //박스콜라이더 컴포넌트를 불러옴.
    private float groundHorizontalLength;


    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }
   
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -groundHorizontalLength) //현재 오브젝트의 중심의 x값이 오브젝트의 길이보다 작아지면
        {
            RepositionBackGround();//메소드 실행.
        }
	}
    private void RepositionBackGround()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0); //
        transform.position = (Vector2)transform.position + groundOffset;
        //                    벡터 3를 벡터2로 캐스팅.
    }
}
