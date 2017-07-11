using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {
	public Transform BulletSpawn;
	public Rigidbody Bullet;

	private float fireRate;
	private float nextFire;
	private baseMob mob;

	private void Awake()
	{
		mob = gameObject.GetComponent<baseMob>();
		fireRate = mob.monster.AttackCoolTime;
	}

	public void shot()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;

			Rigidbody shootingBullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);

			shootingBullet.velocity = BulletSpawn.forward * mob.monster.AttackSpeed;
		}
	}
}
