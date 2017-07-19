using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl_FixVer : MonoBehaviour {

    Transform player;
    public Transform temp;
    Animator anim;
    public float speed = 1f;
    public Transform[] holes = new Transform[4];
    public GameObject projectile;
    Rigidbody rb;
    bool isJumping;
    Vector3 dir;
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
	void FixedUpdate ()
    {
        
        dir = player.position - transform.position;
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (agent.enabled == true)
        {           
            agent.destination = player.position;
            anim.SetBool("isWalk", true);            

        } 
        
    }
    IEnumerator Boss()
    {

        while (true)
        {
            //ChargeAttack(temp);
            agent.enabled = false;
            StartCoroutine("IceAttack");
            yield return new WaitForSeconds(4f);
            agent.enabled = true;
            yield return new WaitForSeconds(2f);

            yield return StartCoroutine("ThreeJump");
            
            StartCoroutine("JumpAttack");
            yield return null;
        }
    }

    IEnumerator ThreeJump() {
        anim.SetBool("isJump", true);
        anim.SetBool("isWalk", false);
        yield return new WaitForSeconds(5f);
    }


    IEnumerator IceAttack()
    {
        int j = 0;
        while (j < 3)
        {
            j++;
            Vector3 viewPos = Camera.main.WorldToViewportPoint(player.transform.position);
            viewPos.y = 1f;
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            for (int i = 0; i < holes.Length; i++)
            {
                holes[0].position = new Vector3(player.position.x, worldPos.y, 0);
                holes[1].position = new Vector3(player.position.x + 6, worldPos.y, 0);
                holes[2].position = new Vector3(player.position.x + 9, worldPos.y, 0);
                holes[3].position = new Vector3(player.position.x - 6, worldPos.y, 0);
            }

            GameObject bullet = (GameObject)Instantiate(projectile, holes[0].position, Quaternion.identity);
            GameObject bullet1 = (GameObject)Instantiate(projectile, holes[Random.Range(1, 2)].position, Quaternion.identity);
            GameObject bullet2 = (GameObject)Instantiate(projectile, holes[Random.Range(3, 4)].position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
            bullet1.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
            bullet2.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);

            yield return new WaitForSeconds(2f);
        }         
    }

    IEnumerator JumpAttack()
    {
        // anim.SetBool("isWalking", false);
        if (grounded && !isJumping)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isWalk", true);
            Jump(30f, -12f, player.localScale.y + 2f, -9.8f);
            yield return new WaitForSeconds(1f);
            yield return null;
        }
    }

    void Jump(float v, float a, float s, float g)
    {
        rb.isKinematic = false;
        if (!isJumping)
        {
            print("jump");
            SoundManager.soundInstance.BossJump();
            /*
            float v = 0f;
            float a = -12f;
            float s = player.localScale.y + 1f;
            float g = -9.8f;
            */
            float u = Mathf.Sqrt(v - 2 * a * s);

            //rb.velocity = Vector3.up * jumpSpeed * Time.deltaTime;
            rb.velocity = Vector3.up * u;
            rb.AddForce(dir.normalized * 200f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !anim.GetBool("isDead"))
            other.gameObject.GetComponent<PlayerHPbar>().TakeDamage(1);

        if(other.gameObject.tag=="Ground")
            rb.isKinematic = true;
    }
}
