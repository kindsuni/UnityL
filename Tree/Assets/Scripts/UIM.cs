using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIM: MonoBehaviour {
    public GameObject[] panels;
        bool up = false;


	// Use this for initialization
	void Start () {
		for(int i= 0; i<panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Upgradesbutton()
    {
        
        int b = 1; //upgradepanel;
        //panels[0].SetActive(true);
        //panels[1].SetActive(true);
        Activeset(b);
    }
   
    void Activeset(int b)
    {
        //bool init = false;
        up = !up;
        print("UP : " + up);
        for(int i = 0; i<panels.Length; i++)
        {
            if (up)
            {
                if (i == b)
                {

                    print("Active");
                    panels[0].SetActive(true);
                    panels[i].SetActive(true);
                    break;
                }
            }
            else
                panels[i].SetActive(false);
        }
    }
}
