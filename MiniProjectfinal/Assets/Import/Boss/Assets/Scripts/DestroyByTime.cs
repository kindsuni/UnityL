using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public GameObject iceEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Player")
            {
                GameObject.Find("Player").GetComponent<PlayerHPbar>().TakeDamage(1);
                SoundManager.soundInstance.Ice();
            }
                GameObject particle = Instantiate(iceEffectPrefab, transform.position, Quaternion.identity);
            Destroy(particle, 0.5f);
            
            MemoryPool.memoryInstance.IceObjectPool.ReturnObject(gameObject);
            //Destroy(gameObject);
        }
    }
}
