using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private baseMob mob;

	private void Awake()
	{
		mob = GameObject.FindGameObjectWithTag("MobB").GetComponent<baseMob>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("King"))
		{
			GameControl.kingHP -= (int)mob.monster.Attack;
			GameControl.instance.PlayerHurtSoundStart();
			GameObject.Find("RealKing(Clone)").GetComponent<Animator>().SetTrigger("IsAttacked");
			GameObject.Find("RealKing(Clone)").GetComponent<Animator>().SetTrigger("IsWalking");
			Destroy();
		}
		else if (other.gameObject.CompareTag("Building"))
		{
			Destroy();
		}
		else if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Animator>().SetTrigger("IsAttacked");
			Destroy();
		}
		else
		{
			Invoke("Destroy", 2.5f);
		}
	}

	void Destroy()
	{
		Destroy(gameObject, 0.1f);
	}
}
