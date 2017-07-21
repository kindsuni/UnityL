using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Clouds
{
    public GameObject cld;
}
public class MoveClouds : MonoBehaviour {
    public List<Clouds> clouds;
   public float moveSpeed = 0.5f;
    float[] spd;
    float[] cloudsposition = new float[1];
   
    // Use this for initialization
    void Start () {      
        spd = new float[clouds.Count];
     
      
        SetMove();               
    }
	
    private void FixedUpdate()
    {        
        if(!Pause.pause)
        _MoveClouds();       
    }
       void SetMove()
        {
        
        for(int i = 0; i < clouds.Count; i++)
        {
            spd[i] = Random.Range(moveSpeed*-1, moveSpeed);
           // print(spd[i]);
            if (spd[i] < 0.1 && spd[i] > -0.1)
            {
              //  print("To Slow :" + clouds[i].cld.name);
                spd[i] *= 10f;
            }
        }
       
        }
    void SetPosition(Clouds cld)
    {
        Transform nowPosition;
        nowPosition = cld.cld.transform;
        cld.cld.transform.position =new Vector2(nowPosition.transform.position.x, Random.Range(-0.5f, 4.5f));
       


    }
    void _MoveClouds()
    {
        for(int i = 0; i<clouds.Count; i++)
        {
            clouds[i].cld.transform.Translate(spd[i]*Time.deltaTime,0, 0);
          //  print("Ismoving :"+clouds[i].cld.name+" Speed Is: " +spd[i]);
            if(clouds[i].cld.transform.position.x >=Camera.main.pixelWidth/40)
            {
                int pos = Random.Range(0, 1);
                cloudsposition[pos] = clouds[i].cld.transform.position.x;

                spd[i] = Random.Range(moveSpeed * -1, moveSpeed);
                if(spd[i]<0.1 && spd[i]>-0.1)
                {
                  //  print("To Slow :"+clouds[i].cld.name);
                    spd[i] *= 10f;
                }
                if(spd[i]>0)
                {
                    spd[i] *= -1;
                }
                SetPosition(clouds[i]);
                
            }
            if (clouds[i].cld.transform.position.x <= -Camera.main.pixelWidth/40)
            {
                spd[i] = Random.Range(-1f, 1f);
                if (spd[i] < 0.1 && spd[i] > -0.1)
                {
                    //print("To Slow :" + clouds[i].cld.name);
                    spd[i] *= 10f;
                }
                if (spd[i] < 0)
                {
                    spd[i] *= -1;
                }
                SetPosition(clouds[i]);


            }

        }

    }
	
}
