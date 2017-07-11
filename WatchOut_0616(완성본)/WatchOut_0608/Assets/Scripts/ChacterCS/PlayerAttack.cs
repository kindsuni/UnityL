using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public AudioClip shootingSound;
	public AudioClip punchSound;
	public float timeBetweenBullets;		// 원거리 공격 쿨타임
	public float timeBetweenMeleeAttack;	// 근거리 공격 쿨타임
	public float farRange;					// 원거리 공격 사정거리
	public float meleeRange;				// 근거리 공격 사정거리
	public float FarAttack;					// 원거리 공격 공격력
	public float MeleeAttack;				// 근거리 공격 공격력

	private float farAttackTimer;			// 최근 원거리 공격으로부터 시간이 얼마나 지났는지 저장해두는 용도
	private float meleeAttackTimer;			// 최근 근거리 공격으로부터 시간이 얼마나 지났는지 저장해두는 용도
	private Ray shootRay = new Ray();
	private RaycastHit shootHit;
	private int shootableMask;
	private ParticleSystem gunParticles;
	private LineRenderer gunLine;
	private Light gunLight;
	private float effectsDisplayTime = 0.2f;

	private AudioSource Sound;
	private Animator anim;

	// Use this for initialization
	void Awake()
	{
		shootableMask = LayerMask.GetMask("Shootable");
		gunParticles = GetComponent<ParticleSystem>();
		gunLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();
		anim = GetComponentInParent<Animator>();

		Sound = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		farAttackTimer += Time.deltaTime;
		meleeAttackTimer += Time.deltaTime;

		// 아래의 조건문은 공격 쿨타임 설정용도
		// meleeAttackTimer >= timeBetweenMeleeAttack && Time.timeScale != 0
		// farAttackTimer >= timeBetweenBullets && Time.timeScale != 0
		if (Input.GetButtonDown("Fire1"))// && meleeAttackTimer >= timeBetweenMeleeAttack && Time.timeScale != 0)
		{
			Punch();
		}
		if (Input.GetButtonDown("Fire2")) //&& farAttackTimer >= timeBetweenBullets && Time.timeScale != 0)
		{
			if (GameControl.playerBullet > 0)
			{
				GameControl.playerBullet--;
				Shoot();
			}
		}

		if (farAttackTimer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects();
		}
	}

	void Punch()
	{
		Sound.clip = punchSound;
		Sound.Play();
		meleeAttackTimer = 0.0f;

		anim.SetBool("IsMelee", true);
		anim.SetBool("IsShot", false);
		Invoke("Idle", 0.33f);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, meleeRange, shootableMask))
		{
			if (shootHit.collider.CompareTag("MobA") || shootHit.collider.CompareTag("MobB") || shootHit.collider.CompareTag("MobC"))
			{
				shootHit.collider.GetComponent<baseMob>().Damage(MeleeAttack);
			}
		}
		else
		{
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * meleeRange);
		}
	}

	void Shoot()
	{
		Sound.clip = shootingSound;
		Sound.Play();

		farAttackTimer = 0.0f;

		gunLight.enabled = true;

		gunParticles.Stop();
		gunParticles.Play();

		anim.SetBool("IsShot", true);
		anim.SetBool("IsMelee", false);
		Invoke("Idle", 0.33f);

		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, farRange, shootableMask))
		{
			gunLine.SetPosition(1, shootHit.point);

			if (shootHit.collider.tag == "MobA" || shootHit.collider.tag == "MobB" || shootHit.collider.CompareTag("MobC"))
			{
				shootHit.collider.GetComponent<baseMob>().Damage(FarAttack);
			}
		}
		else
		{
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * farRange);
		}
	}

	public void DisableEffects()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Idle()
	{
		anim.SetBool("IsIdle", true);
		anim.SetBool("IsShot", false);
		anim.SetBool("IsMelee", false);
	}

}
