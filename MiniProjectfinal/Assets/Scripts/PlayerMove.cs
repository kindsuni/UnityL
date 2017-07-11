using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour {
    [HideInInspector]
    public bool facingRight = true;
    public GameObject weaponPosition;
    Animator anim;
    public float speed = 0f;
    int dir = 1;
    public bool nextStage = false;
   
    //public GameObject Camera;
	// Use this for initialization
	void Start () {
        anim = transform.Find("Penguin").GetComponent<Animator>();
    }
    
	
	// Update is called once per frame
	void Update () {
        //print(Vector3.Distance(transform.position, Camera.main.transform.position));
        if (!Pause.pause)
        {

            if (EventSystem.current.IsPointerOverGameObject()) //UI에 마우스커서가 가면 True
            {
                transform.Translate(((speed * Time.deltaTime) + (5.0f * Time.deltaTime)) * dir, 0f, 0);
                Vector3 viewPos2 = Camera.main.WorldToViewportPoint(transform.position);
                viewPos2.x = Mathf.Clamp01(viewPos2.x);
                Vector3 WorldPos2 = Camera.main.ViewportToWorldPoint(viewPos2);
                WorldPos2.y = 1.5f;
                WorldPos2.z = -0.1f;
                transform.position = WorldPos2;
                return;
            }
            if (anim.GetBool("isDead") == true)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                Flip();
           
            }
          
                transform.Translate(((speed * Time.deltaTime) + (5.0f * Time.deltaTime)) * dir, 0f, 0);
                Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
                viewPos.x = Mathf.Clamp01(viewPos.x);
                Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);
                WorldPos.y = 1.5f;
                WorldPos.z = -0.1f;
                //transform.Translate(WorldPos.x,0f,0);
                transform.position = WorldPos;
            


        }




        
		
	}

    void Flip()
    {
        
        facingRight = !facingRight;
        Vector3 theScale = transform.Find("Penguin").localScale;
        
        theScale.z *= -1;
        transform.Find("Penguin").localScale = theScale;
       
        dir *= -1;

    }
 
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueFish")
        {
            MemoryPool.memoryInstance.BluefishObjectPool.ReturnObject(other.gameObject);
            GameManager.gameManager.AddScore(30);
        }
        if (other.gameObject.tag == "GoldFish")
        {
            MemoryPool.memoryInstance.GoldfishObjectPool.ReturnObject(other.gameObject);
            GameManager.gameManager.AddScore(50);
        }
        if (other.gameObject.tag == "RedFish")
        {
            MemoryPool.memoryInstance.RedfishObjectPool.ReturnObject(other.gameObject);
            GameManager.gameManager.AddScore(10);
        }
    }



}
