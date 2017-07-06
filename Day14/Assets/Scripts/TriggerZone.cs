using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {
    public float damage = 10f;
    public bool isDemage;
    public GameObject Prefab;
    public GameObject Damage;
    private GameObject HealEffect;
    private GameObject DamageEffect;
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onStay(GameObject obj)
    { 
        // obj.SendMessage(isDemage ? "TakeDamage"
        if (isDemage)
        {

            obj.GetComponent<Hpbar>().TakeDamage(damage);
            if (!DamageEffect)
            {
                Vector3 pos = obj.transform.position;
                pos.y = -1f;
                DamageEffect = Instantiate(Damage, pos, obj.transform.rotation);
                Destroy(DamageEffect, 2f);
            }
        }
        else
        {
            obj.GetComponent<Hpbar>().healHP(damage);

            if (!HealEffect)
            {
                Vector3 pos = obj.transform.position;
                pos.y = -1f;
                HealEffect = Instantiate(Prefab, pos, obj.transform.rotation);
                Destroy(HealEffect, 2f);
            }
        }
    }
}
