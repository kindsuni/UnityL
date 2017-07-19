using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TreeController : MonoBehaviour {

    public static int energy = 0; //현재 에너지.
    public static int enegyplus = 1; //클릭당 에너지
    int clicked = 0; //클릭 횟수
    public static int need = 100; //성장 필요에너지
    int jem; //젬
    public static int level = 1; //트리 레벨
    public static int clickneed = 100; //클릭당에너지 업에 필요한 에너지.
    
    float grow = 0.1f; //스케일 성장값.
    bool clickqust = false;
    bool treeupclick = false;
    private TreeController dondestroy;

    private void Awake()
    {
        if(dondestroy == null)
        {
            dondestroy = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        if(!Pause.pause)
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
		if(Input.GetMouseButtonDown(0))
        {         
            energy += enegyplus;           
            clicked++;
        if(clicked >= 10)
        {          
            clickqust = true;
        }
        }
        print("클릭 "+ clicked);
        print("에너지 :"+ energy);
            print(treeupclick);
        }
            }
    }
   public void tree() //트리 성장
    {
        StartCoroutine(treeup());
    }
    public void Clickup() //클릭당 에너지 업
    {
        StartCoroutine(clickup());
    }
    IEnumerator clickup() 
    {
        print(clickneed + "필요함");
        if(clickneed <= energy &&!treeupclick)
        {
           
            yield return StartCoroutine(CanClickup());
        }
        else
        {
            dontClickUp();
            yield return null;
        }
       
    }
   IEnumerator treeup()
    {
        print(need+ " 필요함");
        if(need <= energy && !treeupclick)
        {
           
          yield return StartCoroutine(cantreeup()); //성장 가능.
            
        }
        else
        { //성장에 필요한 에너지 부족.
            dontreeup();
            yield return null;
        }
    }
    //레벨 트리 성장 (스케일, 클릭당 에너지+,트리성장에 필요한 에너지+)
   IEnumerator cantreeup() //레벨 올리고 레벨에 맞는 능력치.
    {
        energy -= need;
        print("남은 에너지 : "+ energy);        
        level++;
        switch(level)
        {
            case 1:
                need = 100;
                enegyplus = 1;
                break;
            case 2:
                need = 250;
                enegyplus += 50;
                break;
            case 3:
                need = 1000;
                break;
            case 4:
                need = 10000;
                break;
            case 5:
                need = 20000;
                break;
            case 6:
                need = 25000;
                break;
            case 7:
                need = 30000;
                break;
            case 8:
                need = 35000;
                break;
            case 9:
                need = 40000;
                break;
            case 10:
                need = 45000;
                break;
            case 11:
                need = 50000;
                break;
            case 12:
                need = 55000;
                break;
            case 13:
                need = 60000;
                break;
            case 14:
                need = 65000;
                break;
            case 15:
                need = 70000;
                break;
            case 16:
                need = 75000;
                break;
            case 17:
                need = 80000;
                break;
            case 18:
                need = 90000;
                break;
            case 19:
                need = 95000;
                break;
            case 20:
                need = 100000;
                break;
        }
       
        
        yield return StartCoroutine(scaleup());
    }
    void dontreeup()
    {
        print("you dont treeup");
    }
    void dontClickUp()
    {
        print("you dont ClickUp");
    }
    IEnumerator CanClickup()
    {
        energy -= clickneed;
        clickneed += 1000;
        enegyplus += 100;
        yield return null;
    }
    

   IEnumerator scaleup()
    {
        grow += 0.01f;
        Vector3 up = gameObject.transform.localScale;
        up.x = grow;
        up.y = grow;
        gameObject.transform.localScale = up;
        yield return null;
    }
}

