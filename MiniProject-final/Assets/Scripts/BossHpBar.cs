using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour {
    public Image currentHPBar;
    public Text ratioText;
    Animator anim;
    private float maxHp = 100;
    public float currentHp;
    private int killScore=1000;
    bool unbeatable = false;
	// Use this for initialization
	void Start () {
        currentHp = maxHp;
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        UpdateHPBar();
	}
    void UpdateHPBar()
    {
        float ratio = currentHp / maxHp;
        if(ratioText!=null)
            ratioText.text = (ratio * 100).ToString("F1") + "%";
        currentHPBar.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
    }

    public void TakeDamage(float amount)
    {
        if (!unbeatable)
        {
            currentHp -= amount;
            if (currentHp <= 0)
            {
                //죽을때
                SoundManager.soundInstance.BossDead();
                //Destroy(gameObject);
                currentHp = 0;
                GameManager.gameManager.AddScore(killScore);
                GameManager.gameManager.GetGun();
                StartCoroutine("Dead");

            }
            UpdateHPBar();
            //StartCoroutine("Damage");
        }
    }

    IEnumerator Dead()
    {
        gameObject.GetComponent<BossControl_FixVer>().enabled = false;
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(2f);
        //anim.SetBool("isDead", false);

        Destroy(gameObject);
        GameManager.gameManager.nextStage();
    }


    IEnumerator Damage()
    {
        int count = 0;
        unbeatable = true;
        while (count < 3)
        {

            gameObject.GetComponent<MeshRenderer>().enabled = false;

            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = true;

            yield return new WaitForSeconds(0.25f);
            count++;
        }
        unbeatable = false;
    }

}
