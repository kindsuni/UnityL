using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    float speed = 5.0f;
    float RotSpeed = 120.0f;

    CharacterController Con;
    Vector3 MoveDirection;
    TriggerZone bo;
    float JumpSpeed = 10.0f;
    float gravity = 20.0f;

    private void Start()
    {
        Con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
      if(Con.isGrounded)
        {
            float amtRot = RotSpeed * Time.deltaTime;

            float ver = Input.GetAxis("Vertical");
            float ang = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * ang * amtRot);

            MoveDirection = new Vector3(0, 0, ver * speed);
            MoveDirection = transform.TransformDirection(MoveDirection);

            if(Input.GetButton("Jump"))
            {
                MoveDirection.y = JumpSpeed;
            }
            
        }
        MoveDirection.y -= gravity * Time.deltaTime;
        Con.Move(MoveDirection * Time.deltaTime);
       
    }
  
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.tag == "Wall" )
        {
            Material mat = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
            if(mat.color != Color.green)
            {
                mat.color = Color.green;
            }
            else 
            {
                mat.color = Color.magenta;
            }

            hit.collider.gameObject.GetComponent<TriggerZone>().onStay(this.gameObject);
        }
    }
   
}
