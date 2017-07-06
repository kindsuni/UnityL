using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlataformController : MonoBehaviour {
    [HideInInspector] //인스펙터에서 안나오게
    public bool facingRight = true; //처음 시작은 오른쪽을 보게.
   // [HideInInspector]
    public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f; //최대 스피드
    public float jumpForce = 1000f;
    public Transform groundCheck; //히어로 밑 그라운드 체크의 위치정보를 가져오기 위함
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame                                                  
    void Update () {//                                                                그라운드에 해당되는 레이어의 비트번호
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

            if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
	}
    private void FixedUpdate()//일정한 시간 단위로 업데이트 보장.(물리 시뮬레이션은 일정하게 업데이트 되야 동일하게 결과값이 나옴.)
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));//애니메이터에 사용하기 위함.
        //                          절대값↑
        if (h * rb2d.velocity.x < maxSpeed)//맥스 스피드를 넘어가지 않을때 까지 계속 힘을줌(속도가 맥스까지 빨라짐)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
            
        }
        if(Mathf.Abs(rb2d.velocity.x)>maxSpeed) //맥스 스피드 넘어서면
        {  //최고 스피드 값으로 고정.                                             현재 Y값 그대로 가져감.
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if(h>0 && !facingRight) //h가 0보다 크면 오른쪽을 보고있어야하는데 왼쪽으로 보고있으면 플립.
        {
            Flip();
        }
        else if(h<0 && facingRight)//작으니 좌측인데 우측 보고있으면 플립.
        {
            Flip();
        }
        if(jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
    void Flip() //뒤집기
    {
        facingRight = !facingRight; //오른쪽
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //스케일 값을 -1로
        transform.localScale = theScale;
    }
}
