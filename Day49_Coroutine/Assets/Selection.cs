using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
	bool isRotating = false; //로테이션 중인지 아닌지 판단함.

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!isRotating) { //로테이션 중이지 않으면 코루틴 실행.
				isRotating = true;
				StartCoroutine (StartRotate());
			}
		}
	}

    // simplified version
    IEnumerator StartRotate()
    {
        yield return StartCoroutine(rotateStage(90f, 1f)); //회전할 각도와 그 각도의 회전시간. 1초동안 90도 회전. 할값을 받을 메소드실행.
        isRotating = false; //메소드가 다 실행되면 로테이션이 끝났으므로 false.
    }

    IEnumerator rotateStage(float angle, float duration) { //회전 각도와 , 그각도를 회전시킬 시간을 받음.
		float remainingAngle = angle; //받은 각도 값을  움직여야할 각도에 저장.
		while(remainingAngle > 0) { //움직여야할각도가 0보다 작지 않으면 while문을 계속 실행.
			float anglePerFrame = Time.deltaTime * angle / duration; //프레임당 각도와 시간을 계산하여 저장.
                // 움직여야할 각도 - 프레임당 움직여야할 각도가 0보다 작은경우 정확히 지정각도만큼 움직이지 않고 더 돌게됨.
            if (remainingAngle - anglePerFrame < 0) //그래서 이렇게 0보다 작아질경우
                anglePerFrame = remainingAngle; //프레임당 움직여야할 각도에 현재 각도값을 저장해서 정확하게 지정한 각도만큼 회전함.
            print (remainingAngle);
			transform.Rotate (Vector3.up * anglePerFrame); //해당 오브젝트를 y축 기준으로 한프레임당 회전해야할 각도만큼 회전.
			remainingAngle -= anglePerFrame; //한프레임에 회전을 했으니 움직여야할 각도에 그값을 차감시킴.
			yield return null; //회전해야할 값이 더이상 없으면 while문을 종료하고 코루틴을 빠져나옴.
		}
	}
}
