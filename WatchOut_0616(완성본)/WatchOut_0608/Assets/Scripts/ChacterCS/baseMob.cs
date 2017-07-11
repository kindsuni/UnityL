using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable]
public class Monster
{
    public float HP, MoveSpeed, Attack,
        AttackSpeed, AttackCoolTime, 
        search, AttackMagnitude;
}

public class baseMob : MonoBehaviour {

	public Monster monster;
	private GameObject Explosion;
	private ParticleSystem ExplosionParticles;
	private Vector3 distance;
	private float timer;
	private Launch launch;

	Transform player;
	Transform targeting;

	NavMeshAgent agent;

	public GameObject damagedParticle;
	public GameObject[] deathParticle;

	void Start()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		launch = gameObject.GetComponent<Launch>();

		player = GameObject.FindGameObjectWithTag("King").transform;
		targeting = GameObject.FindGameObjectWithTag("targeting").transform;
		agent.speed = monster.MoveSpeed;

	}

	private void FixedUpdate()
	{
		timer += Time.fixedDeltaTime;
		distance = player.position - transform.position;

		if (Vector3.Distance(player.position, transform.position) <= monster.search)
		{
			if (distance.magnitude > monster.AttackMagnitude)
			{
				agent.destination = player.position;
			}
			else
			{
				agent.destination = transform.position;

				if (timer >= monster.AttackCoolTime && monster.HP > 0)
				{
					Attack();
				}
				else if (monster.HP <= 0)
				{
					Damage(monster.HP);
				}
			}
		}
	}

	public void Attack()
	{
		timer = 0.0f;

		if (this.gameObject.CompareTag("MobA") || this.gameObject.CompareTag("MobC"))
		{
			GameControl.kingHP -= (int)monster.Attack;
			GameControl.instance.PlayerHurtSoundStart();
			GameObject.Find("RealKing(Clone)").GetComponent<Animator>().SetTrigger("IsAttacked");
			GameObject.Find("RealKing(Clone)").GetComponent<Animator>().SetTrigger("IsWalking");

			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.LookRotation(distance), 0.1f);
		}
		else if (this.gameObject.CompareTag("MobB"))
		{
			transform.LookAt(targeting);
			launch.shot();
		}
	}

	public void Damage(float damage)
	{
		if (monster.HP <= 0)
		{
			Invoke("Death", 0.0f);

			if (this.gameObject.CompareTag("MobA") || this.gameObject.CompareTag("MobB"))
			{
				GameControl.instance.AB_mobDeathSoundStart();
			}
			if (this.gameObject.CompareTag("MobC"))
			{
				GameControl.instance.C_mobDeathSoundStart();
			}
		}
		else
		{
			monster.HP -= damage;
			damagedParticle.GetComponentInChildren<TextMesh>().text = "-" + damage;
			Instantiate(damagedParticle, this.gameObject.transform.position, Quaternion.AngleAxis(180.0f, Vector3.up));
		}
	}

	public void Death()
	{
		if (this.gameObject.tag == "MobA")
		{
			GameObject temp = Instantiate(deathParticle[0], transform.position, transform.rotation) as GameObject;
			Destroy(temp, 1.0f);
		}
		else if (this.gameObject.tag == "MobB")
		{
			GameObject temp = Instantiate(deathParticle[1], transform.position, transform.rotation) as GameObject;
			Destroy(temp, 1.0f);
		}
		else if (this.gameObject.tag == "MobC")
		{
			GameObject temp = Instantiate(deathParticle[2], transform.position, transform.rotation) as GameObject;
			Destroy(temp, 1.0f);
		}

		Destroy(gameObject);
	}

}

