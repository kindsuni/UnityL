using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour {

    Transform player;
    public Transform temp;
    Animator anim;
    public float speed = 1f;
    public Transform[] holes = new Transform[4];
    public GameObject projectile;
    Rigidbody rb;
    bool isJump;

    public Transform groundCheck;
    NavMeshAgent agent;
    bool grounded = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Boss");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = player.position - transform.position;
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (agent.enabled == true)
        {
            agent.destination = player.position;
            anim.SetBool("isWalk", true);
        }
        if (grounded&& !isJump)
        {
            rb.isKinematic = true;
            isJump = false;

        }
        //if (dir.x > 0) // 플레이어가 오른쪽
        //{
        //    //transform.rotation = Quaternion.Euler(-90f, 90f, 0f);
        //    Vector3 viewPos = Camera.main.WorldToViewportPoint(player.transform.position);
        //    viewPos.x = 1f;
        //    Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);
        //    temp.position = WorldPos;


        //}
        //else  // 플레이어가 왼쪽
        //{
        //   // transform.rotation = Quaternion.Euler(-90f, 0, -90f);
        //    Vector3 viewPos = Camera.main.WorldToViewportPoint(player.transform.position);
        //    viewPos.x = 0f;
        //    Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);
        //    temp.position = WorldPos;


        //}
    }
    IEnumerator Boss()
    {

        while (true)
        {
            //ChargeAttack(temp);
            agent.enabled = false;
            IceAttack();
            yield return new WaitForSeconds(1f);
            IceAttack();
            yield return new WaitForSeconds(1f);
            IceAttack();
            yield return new WaitForSeconds(1f);
            agent.enabled = true;
            yield return new WaitForSeconds(2f);
        }
    }



    void ChargeAttack(Transform temp)
    {

        
        Jump(0f, -12f, player.localScale.y + 1.5f, -9.8f);
         //transform.position = Vector3.MoveTowards(transform.position, new Vector3(temp.position.x, transform.position.y, 0), speed * Time.deltaTime);
        //  print(temp.position.x);

    }
    void IceAttack()
    {
        holes[0].position = new Vector3(player.position.x, 8, 0);
        holes[1].position = new Vector3(player.position.x + 6, 8, 0);
        holes[2].position = new Vector3(player.position.x + 9, 8, 0);
        holes[3].position = new Vector3(player.position.x - 6, 8, 0);
               
        GameObject bullet = (GameObject)Instantiate(projectile, holes[0].position, Quaternion.identity);
        GameObject bullet1 = (GameObject)Instantiate(projectile, holes[Random.Range(1, 2)].position, Quaternion.identity);
        GameObject bullet2 = (GameObject)Instantiate(projectile, holes[Random.Range(3, 4)].position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
        bullet1.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
        bullet2.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);

            

        
       
    }



    void Jump(float v, float a, float s, float g)
    {
        if (!isJump)
        {
            isJump = true;
            rb.isKinematic = false;
            print("Jump");
            /*
            float v = 0f;
            float a = -12f;
            float s = player.localScale.y + 1f;
            float g = -9.8f;
            */
            float u = Mathf.Sqrt(v - 2 * a * s);

            //rb.velocity = Vector3.up * jumpSpeed * Time.deltaTime;
            rb.velocity = Vector3.up * u*100f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !anim.GetBool("isDead"))
            other.gameObject.GetComponent<PlayerHPbar>().TakeDamage(1);
    }
}
