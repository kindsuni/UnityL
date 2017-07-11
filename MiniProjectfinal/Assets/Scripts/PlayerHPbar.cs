using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHPbar : MonoBehaviour {
    //public Image loadingBar;
    //public Image hpPanel;
    public GameObject penguin;
     GameObject hpPanel;
    Animator anim;
    Showpanel panels;
  
    private float maxHP = 3;
    private float currentHP;
   public bool unbeatable = false;
    bool active = true;
    private void Awake()
    {
        hpPanel = GameObject.Find("HpPanel");
        anim = transform.Find("Penguin").GetComponent<Animator>();
       
    }
    void Start() {
        currentHP = maxHP;
        UpdateHPBar();
        
    }

    
    void Update() {

    }

    void UpdateHPBar()
    {
        // float ratio = currentHP / maxHP;
        //loadingBar.fillAmount = ratio;
        if (currentHP == 3)
        {
            for (int i = 0; i < hpPanel.transform.childCount; i++)
            {
                hpPanel.transform.GetChild(i).gameObject.SetActive(!active);
            }

            hpPanel.transform.Find("HPFull").gameObject.SetActive(active);


        }
        else if (currentHP == 2)
        {
            for (int i = 0; i < hpPanel.transform.childCount; i++)
            {
                hpPanel.transform.GetChild(i).gameObject.SetActive(!active);
               
            }
            hpPanel.transform.Find("HP2").gameObject.SetActive(active);
        }
        else if (currentHP == 1)
        {
            for (int i = 0; i < hpPanel.transform.childCount; i++)
            {
                hpPanel.transform.GetChild(i).gameObject.SetActive(!active);
                
            }
            hpPanel.transform.Find("HP1").gameObject.SetActive(active);
        }
        else
        {
            for (int i = 0; i < hpPanel.transform.childCount; i++)
            {
                //죽을때
               
                hpPanel.transform.GetChild(i).gameObject.SetActive(!active);
            }
            hpPanel.transform.Find("HP0").gameObject.SetActive(active);
        }


    }
    void GoDead()
    {
        SceneManager.LoadScene("DeadScene");
    }
    public void TakeDamage(float amount)
    {
        if (!Pause.pause)
        {
            if (!unbeatable)
            {
               
                currentHP -= amount;
                if (currentHP <= 0)
                {
                    currentHP = 0;
                    SoundManager.soundInstance.PlayerDead();
                    anim.SetBool("isDead", true);
                    print("PlayerDead");
                    GameManager.gameManager.Lose();
                    Invoke("GoDead", 2f);
                }
               
                UpdateHPBar();
            
                StartCoroutine("Damage");
             }

        }
    }
    IEnumerator Damage()
    {
        if (!Pause.pause)
        {

            int count = 0;
        unbeatable = true;
        while (count<3)
        {
            
            penguin.GetComponent<SkinnedMeshRenderer>().enabled = false;
            
            yield return new WaitForSeconds(0.25f);
            penguin.GetComponent<SkinnedMeshRenderer>().enabled = true;
            
            yield return new WaitForSeconds(0.25f);
            count++;
        }
        unbeatable = false;
        }
     }
    }

