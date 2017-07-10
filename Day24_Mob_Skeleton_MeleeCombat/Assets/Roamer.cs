using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Roamer : MonoBehaviour {

    public Transform player; //플레이어 위치
    Animator anim;
    
    public GameObject[] wayPoints; //이동해야할 위치의 개수와 각위치.
    public int currentPoint = 0; //초기 위치는 0부터 시작.
    public float moveSpeed = 1; //이동속도.

    private Vector3 nextPoint;  //이동해야할 위치.

    private NavMeshAgent agent; //네비 메시

    // Use this for initialization
    void Start()
    { //컴포넌트를 받아옴.
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        //현재이동 위치가 이동해야할 위치의 개수보다 크면 안되니 0으로 초기화시켜줌.
        if (currentPoint >= wayPoints.Length)
            currentPoint = 0;
        //이동해야할 위치의 개수가 2보다 크고, 현재 이동위치가 이동해야할 위치 개수보다 작을경우
        if (wayPoints.Length >= 2 && currentPoint < wayPoints.Length)
            //이동해야할 위치의 배열은 현재 이동해야할 위치의 포지션이다. 처음에 초기화 해주는 역할.
            nextPoint = wayPoints[currentPoint].transform.position;
       
        // for gizmo  현재 이동해야할 위치는 노란색, 아닌경우는 마젠타.
        for (int i = 0; i < wayPoints.Length; i++)
            wayPoints[i].GetComponent<MeshRenderer>().material.color = Color.magenta;
        wayPoints[currentPoint].GetComponent<MeshRenderer>().material.color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {
       //플레이어의 isDead판정이 트루이면 죽음, 펄스면 살아있음을 표시함.
        bool playerAlive = !player.GetComponent<Animator>().GetBool("isDead");
        //몹의 isDead판정이 트루이면 죽음, 펄스면 살아있음을 표시.
        bool mobAlive = !GetComponent<Animator>().GetBool("isDead");

        Vector3 direction = player.position - transform.position; //벡터 산출(플레이어 위치에서 현재위치를 뺌).
        float angle = Vector3.Angle(direction, transform.forward);
        //플레이어와 몹의 거리가 10이하 이고 몹의 바라보는 45도방향안에 플레이어가 있고, 플레이어가 살아있다면.(플레이어 상호작용)
		if (Vector3.Distance(player.position, transform.position) < 10 && angle < 45 && playerAlive)
        {
            direction.y = 0;
            //어택킹이 아니면
            if (!anim.GetBool("isAttacking")&& mobAlive)
            { // 몹의 회전방향은 플레이어의 위치에서 현재위치를 뺀 방향값.
                transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
            }


            anim.SetBool("isIdle", false);
            if (direction.magnitude > 5)
            {
                // Walking
                //transform.Translate(0, 0, 0.05f);
                agent.destination = player.position;

                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                // Attacking
				anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }

        }
        else // 로밍 작용.(플레이어가 없는경우)
        {
            if (!mobAlive) //몹이 살아있지 않다면
                return; //리턴

            anim.SetBool("isIdle", false); //애니메이션 상태.
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);

            if (wayPoints.Length >= 2 &&mobAlive) //배열이 적어도 2개 이상은 있어야 함.(와리가리 해야한다면 두개는 있어야되니)
            { // dist의 값 산출.(현재위치에서 이동해야할 위치의 거리, 가변함)
                float dist = Vector3.Distance(transform.position, nextPoint);
				if (dist < 0.4f)	// threadhold 값이 너무 작으면 dir vector가 identity가 되어 LookRotation()을 제대로 못 구함
                {// dist가 0.4보다 작아지면 몹이 이동해야할 위치에 도달했다고 판정
                    currentPoint++; //다음위치로 이동
                    if (currentPoint >= wayPoints.Length) //다음위치가 이동해야할 개수보다 커지면
                        currentPoint = 0; //0으로 초기화 해서 다시 처음으로 이동.
                    nextPoint = wayPoints[currentPoint].transform.position; // 갱신됨.

                    // for gizmo
                    wayPoints[currentPoint].GetComponent<MeshRenderer>().material.color = Color.yellow;
                    if (currentPoint == 0)
                        wayPoints[wayPoints.Length-1].GetComponent<MeshRenderer>().material.color = Color.magenta;
                    else
                        wayPoints[currentPoint-1].GetComponent<MeshRenderer>().material.color = Color.magenta;

                }

                //Vector3 dir = nextPoint - transform.position;
                //dir.y = 0f;
                //무브먼트.
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), 0.1f);
                //transform.position = Vector3.MoveTowards(transform.position, nextPoint, moveSpeed * Time.deltaTime);
                ////transform.position = Vector3.Lerp(transform.position, nextPoint, moveSpeed * Time.deltaTime / dist);
                //네비 찾아서 이동.
                if(mobAlive)
                agent.destination = nextPoint;
            }
        }
    }

}
