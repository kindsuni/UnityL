using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {
    bool jumping = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) &&!jumping)   //스페이스바를 누르면 코루틴 실행.
        {
            jumping = true; //키를 한번 누르면 더이상 실행되지 못하게 막음.
            StartCoroutine(ThreeJumpAttack()); //코루틴을 실행.
            //Jump();
        }
	}

    IEnumerator ThreeJumpAttack() 
    {
        Jump(3f); //점프 메소드를 실행한다. 3f는 높이값.
        yield return new WaitForSeconds(1.8f); //1.8초를 기다리고. 다음 줄 실행.
        Jump(3f); //1.8초를 기다린후 넘어왔으니 점프 메소드 다시 실행.
        yield return new WaitForSeconds(1.8f); //1.8초를 기다린후 다음줄 실행
		yield return WheelWindJump(5f); //메소드 실행.
        jumping = false; //모든 과정이 다 끝났으니 다음 행동으로 넘어 갈수 있게 함.
        //StartCoroutine(ThreeJumpAttack());

    }

	void Jump(float height) //float 높이 값을 받아서 해당 오브젝트의 Rigidbody컴포넌트를 가져오고 그 벨로시티의 Y값을 변화시킴.
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = rb.velocity;
		velocity.y = Mathf.Sqrt(2.0f * 9.8f * height); //y값에 가속 * 중력 * 높이로 점프하게됨. (값을 저장)
        rb.velocity = velocity; //저장한 값을 직접 rb컴포넌트에 넣어 실제로 구동됨.
        print("Jump");
    }
		
	IEnumerator WheelWindJump(float height) { //높이 값을 받아서 점프 실행.
		Rigidbody rb = GetComponent<Rigidbody>(); //해당 오브젝트의 Rigidbody컴포넌트를 가져옴.
		Vector3 velocity = rb.velocity; // 임의의 벡터에 현재 오브젝트의 벨로시티값을 저장.
		velocity.y = Mathf.Sqrt(2.0f * 9.8f * height); //저장된 벨로시티 값에 계산된값을 더해줌.
		rb.velocity = velocity; //계산된 값을 실제 오브젝트에 적용하여 구동함.
		rb.AddTorque(Vector3.up * 100f, ForceMode.Impulse); //오브젝트의 y축을 로테이션함.
		print("WheelWindJump");
		yield return new WaitForSeconds (2.0f); //2초를 기다린후 while문 실행.(땅에 닿은상황.)

		while (true) {
			rb.AddTorque(rb.angularVelocity * -0.5f * Time.deltaTime, ForceMode.Impulse); // 반대방향으로 회전힘을 주어서 멈추게함.(한 프레임당 힘을줌)
			if (rb.angularVelocity.magnitude < 1) //오브젝트의 회전값이 1보다 작아지면 while문 종료 (더이상 회전하고 있지 않음.)
				break;
			yield return null; //1보다 작지 않으면 while문 계속 실행.(한 프레임씩)
                               //while문을 빠져나오면 회전이 1보다 작아진 상태로 미세하게 회전하고있는 상태다. 
		}
        //지금 원하는것은 완전히 회전을 멈추는 것이기 때문에 회전을 zero로 해서 미세한 회전을 아예 차단한다.
		rb.angularVelocity = Vector3.zero; 
		print("WheelWindJump stopped");
	}
}
