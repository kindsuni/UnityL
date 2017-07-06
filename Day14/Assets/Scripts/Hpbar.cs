using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hpbar : MonoBehaviour {

    public float Damage = 10.0f;
    float maxhp = 150.0f;
   public  float currentHP = 150.0f;
   // public bool isdamaging;
    public Image greenbar;
   public  Text HP;
    Damagingzone check;
    
   
	void Start () {
        
        HP.GetComponent<Text>();
        greenbar.GetComponent<Image>();
        
	}
	
	
	void Update () {
        HPCheck();
        //damagingCheck();

    }
    void HPCheck()
    {
        float ratio = currentHP / maxhp;

        greenbar.rectTransform.localScale = new Vector3(ratio, 0.5f, 1);
        HP.text = (ratio * 100).ToString("F1") + "%";

    }
    //내가 짜본거 구현 검증용
    void damagingCheck()
    {
        float ratio = currentHP / maxhp;
        HP.text = (ratio * 100).ToString("F1") + "%"; //소수 1째 자리까지 표현.

        if (check.isdamaging)
        {
            if (currentHP > 0)

                currentHP--;
            greenbar.rectTransform.localScale = new Vector3(ratio, 0.5f, 1);
            print(ratio);

            if (currentHP < 0)
            {
                currentHP = 0;
            }
        }


        else
        {
            
            greenbar.rectTransform.localScale = new Vector3(ratio, 0.5f, 1);
        }
    }
    // 데미지를 받는 메소드
    public void TakeDamage(float amount) // 데미지 값을 받아서 현재 HP에 계산함.
    {
        currentHP -= amount*Time.deltaTime;
        if (currentHP < 0)
            currentHP = 0;
    }

   public  void healHP(float amount)
    {
            currentHP += amount*Time.deltaTime;
        
        if(currentHP > maxhp)
        {
            currentHP = maxhp;
        }
    }
}
