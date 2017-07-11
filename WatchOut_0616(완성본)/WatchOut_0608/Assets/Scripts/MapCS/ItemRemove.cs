using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour {

	public AudioClip bulletSound;
	public AudioClip hpSound;

	private GameControl GM;

	private void Start()
	{
		GM = GameObject.Find("GameMaster").GetComponent<GameControl>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (this.gameObject.CompareTag("ItemBullet"))
			{
				if (GameControl.playerBullet + GameControl.itemBullet > GameControl.playerFullBullet)
					GameControl.playerBullet = GameControl.playerFullBullet;
				else if (GameControl.playerBullet < GameControl.playerFullBullet)
					GameControl.playerBullet += GameControl.itemBullet;

				GM.BulletItemSoundStart();

				Destroy(GameObject.Find("Kits"));
			}
			else if (this.gameObject.CompareTag("ItemHP"))
			{
				if (GameControl.kingHP + GameControl.itemHP > GameControl.kingFullHP)
					GameControl.kingHP = GameControl.kingFullHP;
				else if (GameControl.kingHP < GameControl.kingFullHP)
					GameControl.kingHP += GameControl.itemHP;

				GM.HPItemSoundStart();

				Destroy(GameObject.Find("Kits"));
			}
		}
	}
}
