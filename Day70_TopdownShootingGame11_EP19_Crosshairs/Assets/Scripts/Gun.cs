﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public enum FireMode { Auto, Burst, Single };
	public FireMode fireMode;

	public Transform[] projectileSpawn;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;
	public int burstCount;

    [Header("Effect")]
	public Transform shell;
	public Transform shellEjection;
    public AudioClip shootAudio;
    public AudioClip reloadAudio;

	MuzzleFlash muzzleFlash;
	float nextShotTime;

	bool triggerReleasedSinceLastShot;
	int shotsRemainingInBurst;

	void Start() {
		muzzleFlash = GetComponent<MuzzleFlash> ();
		shotsRemainingInBurst = burstCount;
	}

	void Shoot() {

		if (Time.time > nextShotTime) {
			if (fireMode == FireMode.Burst) {
				if (shotsRemainingInBurst == 0) {
					return;
				}
				shotsRemainingInBurst --;
			}
			else if (fireMode == FireMode.Single) {
				if (!triggerReleasedSinceLastShot) {
					return;
				}
			}

			for (int i = 0; i<projectileSpawn.Length; i++) {
				nextShotTime = Time.time + msBetweenShots / 1000;
				Projectile newProjectile = Instantiate (projectile, projectileSpawn[i].position, projectileSpawn[i].rotation);
				newProjectile.SetSpeed (muzzleVelocity);
			}

			Instantiate(shell, shellEjection.position, shellEjection.rotation);
			muzzleFlash.Activate ();

            AudioManger.instance.PlaySound(shootAudio, transform.position);
            
        }
	}

	public void OnTriggerHold() {
		Shoot ();
		triggerReleasedSinceLastShot = false;
	}

	public void OnTriggerRelease() {
		triggerReleasedSinceLastShot = true;
		shotsRemainingInBurst = burstCount;
	}
}