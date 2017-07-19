using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossScript : MonoBehaviour {
    public GameObject earthquakePrefab;
    //Animator anim;
    public Transform[] spots;
    public float speed=3f;
    public float jumpSpeed = 10f;
    public Transform[] holes = new Transform[4];
    public GameObject projectile;
    Transform player;
    Vector3 playerPos;
    Rigidbody rb;
    public bool isJump;
    Transform temp;
    Vector3 dir;
    void Start () {
        temp = spots[1];
        //anim = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Boss");
        
	}

    // Update is called once per frame
    void Update()
    {
        //anim.SetTrigger("Stand");
        playerPos = player.position;
        
       

       
        dir = playerPos - transform.position;

        print(dir.x);
        if (dir.x > 0) // 플레이어가 왼쪽에있을때
        {
            transform.rotation = Quaternion.Euler(-90f, 90f, 0f);
            temp = spots[1];
        }
        else //플레이어가 오른쪽에 있을때
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            temp = spots[0];
        }
    }
    
    IEnumerator Boss() {
        StartCoroutine("ChargeAttack", temp);
        yield return new WaitForSeconds(3f);
        while (true) {
            int ranLength = 3;
            int[] r = Enumerable.Range(0, ranLength).ToArray();
            for (int i = 0; i < ranLength; ++i)
            {
                int ranIdx = Random.Range(i, ranLength);

                int tmp = r[ranIdx];
                r[ranIdx] = r[i];
                r[i] = tmp;
                switch (r[i])
                {
                    case 0:
                        StartCoroutine("ChargeAttack", temp);
                        yield return new WaitForSeconds(6f);
                        break;
                    case 1:
                        StartCoroutine("IceAttack");
                        yield return new WaitForSeconds(6f);
                        break;
                    case 2:
                        StartCoroutine("JumpAttack");
                        yield return new WaitForSeconds(6f);
                        break;
                }
                yield return null;
            }           
            yield return null;
        }       
    }
    void Jump(float v, float a, float s, float g) {

        //anim.SetTrigger("Attack");



        if (!isJump)
        {
            isJump = true;
            /*
            float v = 0f;
            float a = -12f;
            float s = player.localScale.y + 1f;
            float g = -9.8f;
            */
            float u = Mathf.Sqrt(v - 2 * a * s);

            //rb.velocity = Vector3.up * jumpSpeed * Time.deltaTime;
            rb.velocity = Vector3.up * u;
        }
       
       
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        isJump = false;
        // rb.AddForce(Vector3.left * 50f);
    }

    IEnumerator IceAttack() {
        int j = 0;
        while (j < 3)
        {
            j++;
            for (int i = 0; i < holes.Length; i++)
            {
                holes[0].position = new Vector3(playerPos.x, 8, 0);
                holes[1].position = new Vector3(playerPos.x + 3, 8, 0);
                holes[2].position = new Vector3(playerPos.x + 6, 8, 0);
                holes[3].position = new Vector3(playerPos.x - 3, 8, 0);
                holes[4].position = new Vector3(playerPos.x - 6, 8, 0);
                yield return null;
            }
            GameObject bullet = (GameObject)Instantiate(projectile, holes[0].position, Quaternion.identity);
            GameObject bullet1 = (GameObject)Instantiate(projectile, holes[Random.Range(1, 3)].position, Quaternion.identity);
            GameObject bullet2 = (GameObject)Instantiate(projectile, holes[Random.Range(3, 5)].position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
            bullet1.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
            bullet2.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
            
            yield return new WaitForSeconds(2f);
           
        }        
    }

    IEnumerator ChargeAttack(Transform temp) {
        while (transform.position.x != temp.position.x)
        {
            Jump(0f, -12f, player.localScale.y + 1.5f, -9.8f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(temp.position.x, transform.position.y, 0), speed*Time.deltaTime);
            yield return null;
        }
        
    }
    IEnumerator JumpAttack() {
        //Second Attack
        rb.isKinematic = true;
        while (transform.position.x != spots[2].position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, spots[2].position, jumpSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        rb.isKinematic = false;
        float pPos = playerPos.x;
        while (transform.position.x != pPos)
        {
            GameObject eqParticle = Instantiate(earthquakePrefab, new Vector3(pPos, 0, 0), Quaternion.identity);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pPos, 0, 0), jumpSpeed *  Time.deltaTime);
            Destroy(eqParticle, 2f);
            yield return null;
        }
        while (!isJump) {
            Jump(0f, -12f, player.localScale.y + 1f, -9.8f);
            yield return null;
        }
    }
}
