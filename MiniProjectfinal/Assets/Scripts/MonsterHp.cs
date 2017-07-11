using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour {
    public Image currentHPBar;
    private float maxHp = 100;
    public float currentHp;
    private int killScore = 100;
    Animator anim;
  
    void Start () {
        currentHp = maxHp;
        anim = GetComponent<Animator>();
    }
	
	
	void Update () {
        UpdateHPBar();

    }

    void UpdateHPBar()
    {
        float ratio = currentHp / maxHp;
      
        currentHPBar.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        
    }

    public void TakeDamage(float amount)
    {
            if(currentHp>0)    
                currentHp -= amount;
            if (currentHp <= 0 && !anim.GetBool("isDead"))
            {
          
                currentHp = 0;
                GameManager.gameManager.AddScore(killScore);
                if (gameObject.tag == "Monster") 
                    SoundManager.soundInstance.PlaySound();
                StartCoroutine("Dead");
            }
            
            UpdateHPBar();
         
        
    }

    IEnumerator Dead()
    {
       // gameObject.GetComponent<EnemyControl>().enabled = false;
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(3.9f);
        
        
        
        currentHp = maxHp;
        if (GetComponent<EnemyControl>().isresurrection)
            Destroy(gameObject);
        else
        {
            GetComponent<EnemyControl>().isresurrection = true;
            MemoryPool.memoryInstance.MonsterObjectPool.ReturnObject(gameObject);
            anim.SetBool("isDead", false);
        }
    }
    


}
