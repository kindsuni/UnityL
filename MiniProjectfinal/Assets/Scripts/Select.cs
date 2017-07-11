using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Charactor
{
    public GameObject chr;
}
public class Select : MonoBehaviour
{

    public List<Charactor> chracto;
    public static int i = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Charactor cha = chracto[i];

        //cha.chr.SetActive(true);

        setactive();
        print(i);
    }

    public void setactive()
    {
        for (int ch = 0; ch < 4; ch++)
        {
            if (ch == i)
            {
                chracto[ch].chr.SetActive(true);
            }
            else
            {
                chracto[ch].chr.SetActive(false);

            }
        }
        //Charactor cha = chracto[0];
        //Charactor cha2 = chracto[1];
        //Charactor cha3 = chracto[2];
        //Charactor cha4 = chracto[3];
        //if (i==0)
        //{
        //    print("james");
        //    cha.chr.SetActive(true);
        //    cha2.chr.SetActive(false);
        //    cha3.chr.SetActive(false);
        //    cha4.chr.SetActive(false);
        //}
        //if(i==1)
        //{
        //    print("Chars");
        //    cha.chr.SetActive(false);
        //    cha2.chr.SetActive(true);
        //    cha3.chr.SetActive(false);
        //    cha4.chr.SetActive(false);
        //}
        //if(i ==2)
        //{
        //    print("LuisPanel");
        //    cha.chr.SetActive(false);
        //    cha2.chr.SetActive(false);
        //    cha3.chr.SetActive(true);
        //    cha4.chr.SetActive(false);
        //}
        //if(i==3)
        //{
        //    print("Alice");
        //    cha2.chr.SetActive(false);
        //    cha.chr.SetActive(false);
        //    cha3.chr.SetActive(false);
        //    cha4.chr.SetActive(true);

        //}
    }
}
