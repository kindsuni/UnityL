using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool m_mouseLockFlag; //마우스가 락인지 아닌지 

    public GameObject playerObject = null; //플레이 오브젝트를 기억하는.
    GameObject ca;
    //상수 정의(대문자)


    private static readonly float MOVE_Z_FRONT = 3.0f;
    private static readonly float Run = 2.0f;
    private static readonly float MOVE_Z_BACK = -2.0f;
    private static readonly float MOVE_X_RIGHT = 3.0f;
    private static readonly float MOVE_X_LEFT = -3.0f;
    private static readonly float ROTATION_Y_KEY = 360.0f;
    private static readonly float ROTATION_Y_MOUSE = 360.0f;
    private static readonly float ROTATION_X_MOUSE = 360.0f;


    private float m_rotationY = 0.0f; //내부적으로 한번에 한프레임 내에서 임시로 사용하는 값 
    private float m_rotationX = 0.0f;
    bool jumping = true;    
    
    public GameObject bulletObject = null;//총알 프리팹
    GameObject go;
    MyCameraManager mc;
    public Transform bulletStartPosition = null; //총알 시작지점.
    GameObject UpperBody;// = GameObject.Find("Character1_Spine");
    // Use this for initialization
    void Start ()
    {
        go = GameObject.Find("CameraManager");
         mc = go.GetComponent<MyCameraManager>();
        mc.MainCameraOn();

      //  UpperBody = GameObject.Find("Character1_Neck");
         UpperBody = GameObject.Find("Character1_Spine");
    }
    private void LateUpdate()
    {

        UpperBody.transform.localEulerAngles = new Vector3(0, 0, m_rotationX);
      
        
    }
    // Update is called once per frame
    void Update () {

        CheckMouseLock();
        CheckMove();
        Jump();
       // UpperBody.transform.rotation = Quaternion.Euler(m_rotationX, 0, 0);
    }
    private  void CheckMouseLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_mouseLockFlag = !m_mouseLockFlag;
        }

        if(m_mouseLockFlag)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mc.SubCameraOn();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mc.MainCameraOn();
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode.VelocityChange);
            // rb.AddForce(new Vector3(0f, 250f, 0f));
        }
       
    }
    

    private void CheckMove()
    {
        
        //회전량
        {
            float addRotationY = 0.0f;
            float addRotationX = 0.0f;
            if (Input.GetKey(KeyCode.Q))
            {
                addRotationY = -ROTATION_Y_KEY;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                addRotationY = ROTATION_Y_KEY;
            }
            if(m_mouseLockFlag) //마우스 락 있을때만 회전함.
            {
                addRotationY += (Input.GetAxis("Mouse X") * ROTATION_Y_MOUSE);
               
                addRotationX += (Input.GetAxis("Mouse Y") * ROTATION_X_MOUSE);
               
                if(m_rotationX>=50)
                {
                    m_rotationX = 50;
                }
                if(m_rotationX<0 &&m_rotationX <= -80)
                {
                    m_rotationX = -80;
                }
            }
            m_rotationY += (addRotationY * Time.deltaTime);
            m_rotationX += (addRotationX * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, m_rotationY, 0);

        }
        Vector3 addPositoin = Vector3.zero;
        {
            Vector3 vecinput = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
            if (vecinput.z > 0)
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    addPositoin.z = MOVE_Z_FRONT + Run;
                }
                else
                {
                    addPositoin.z = MOVE_Z_FRONT;
                }
            }
            else if (vecinput.z < 0)
            {
                addPositoin.z = MOVE_Z_BACK;
            }//       항상 월드 기준으로 바꿔야 함           월드기준     한프레임당움직임

            Vector3 horinput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

            if (horinput.x > 0)
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    addPositoin.x = MOVE_X_RIGHT + Run;
                }
                else
                {
                    addPositoin.x = MOVE_X_RIGHT;
                }
            }
            else if (horinput.x < 0)
            {
                addPositoin.x = MOVE_X_LEFT;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    addPositoin.x = MOVE_X_LEFT + (-Run);
                }
                else
                {
                    addPositoin.x = MOVE_X_LEFT;
                }


            }
            transform.position += ((transform.rotation * addPositoin) * (Time.deltaTime));
        }
     
           
        

        bool ShootFlag = false;
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootFlag = true;
                if(null !=bulletStartPosition)
                {
                   
                   Vector3 vecBulletPos = bulletStartPosition.position;
                   
                    vecBulletPos += (transform.rotation * Vector3.forward);
                    vecBulletPos.y =0.5f;
                                 //이 오브젝트를  
                    Instantiate(bulletObject, vecBulletPos, transform.rotation);
                }
            }
            else
            {
                ShootFlag = false;
            }
        }
        

        {
            Animator animator = playerObject.GetComponent<Animator>();
            animator.SetFloat("SpeedX", addPositoin.x);
            animator.SetFloat("SpeedZ", addPositoin.z);
            animator.SetBool("Shoot", ShootFlag);
            animator.SetBool("Jumping",isGrounded());
        }
    }
    
    
    bool isGrounded()
    {


        GameObject foot = GameObject.Find("JumpState");
        GameObject foot2 = GameObject.Find("JumpState (1)");
        return Physics.Raycast(foot.transform.position, Vector3.down, 0.2f) || Physics.Raycast(foot2.transform.position, Vector3.down, 0.2f); //레이저를 밑으로 0.2f만큼만 쏘아서 닿은상태라면 True, 안닿으면 false;
       


    }

   
}
