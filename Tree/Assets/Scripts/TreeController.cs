using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TreeController : MonoBehaviour {

    public static int energy = 0;
    int enegyplus = 1;
    int clicked = 0;
    int j = 0;
    int need = 100;
    int clickneed = 0;
    float grow = 0.1f;
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
   public void tree()
    {
        StartCoroutine(treeup());
    }
    public void Clickup()
    {
        StartCoroutine(clickup());
    }
    IEnumerator clickup()
    {
        print("클릭당 에너지 :"+ enegyplus);
        enegyplus += 5;
        yield return null;
    }
   IEnumerator treeup()
    {
        print(need+ " 필요함");
        if(need <= energy && !treeupclick)
        {
            treeupclick = true;
          yield return StartCoroutine(cantreeup());
            yield return StartCoroutine(needup());
        }
        else
        {
            dontreeup();
            yield return null;
        }
    }
   IEnumerator cantreeup()
    {
        energy -= need;
        print("남은 에너지 : "+ energy);
        yield return null;
    }
    void dontreeup()
    {
        print("you dont treeup");
    }
    IEnumerator needup()
    {
        treeupclick = false;
        need += 50;
        yield return StartCoroutine(scaleup());
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

