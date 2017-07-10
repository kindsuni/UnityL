using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
    bool keyDown = false; // 둘중 아무 키를 누르고 실행이 끝날때까지 다른키를 눌러도 코루틴이 실행되지 않도록 하기 위함.
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) //I키 누르면 코루틴 실행. 페이드 인 메소드 실행
        {
			StartCoroutine(FadeIn());
        }
		if (Input.GetKeyDown(KeyCode.O))//O키 누르면 코루틴 실행. 페이드 아웃 메소드 실행
        {
			StartCoroutine(FadeOut());
		}
    }

    IEnumerator FadeIn() 
    { //for문을 한 프레임마다 실행함. f가 0보다 작거나 같아질때 까지.
        if(!keyDown)
        {
            keyDown = true; //트루가 되면서 키를 눌러도 여러번 작동되지 않게 됨.
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>(); // 메시 렌더러 컴포넌트를 가져옴.
            Color c = renderer.material.color; // 컬러를 가져옴.
            c.a = f; // 알파값을 f로 조절 가능하게 함.
            renderer.material.color = c; //변한 값을 직접 실행.
            yield return null; //리턴 하고 다시 실행. f가 0보다 작을때 까지.
            //yield return new WaitForSeconds(Time.deltaTime); //위의 return null과 같은 맥락. Time.deltaTime이 한프레임당 실행되는 값.
            //>>
        }
            keyDown = false; //코루틴 for문을 다 돌고 빠져나오고 false로 바뀌면서 다음 작동을 기다림.
        }
    }

	IEnumerator FadeOut()
	{
        if(!keyDown)
        {
            keyDown = true;
		for (float f = 0f; f <= 1; f += 0.01f)
		{
			MeshRenderer renderer = GetComponent<MeshRenderer>();
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			yield return null;
		}
            keyDown = false;
        }
	}

}
