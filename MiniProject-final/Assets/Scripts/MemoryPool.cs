using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : MonoBehaviour {
    

    public static MemoryPool memoryInstance;
   
    public GameObject player;
 
    

    public int wallPoolSize = 30;
    public float spawnRate = 3;

    public SimpleObjectPool BluefishObjectPool;
    public SimpleObjectPool GoldfishObjectPool;
    public SimpleObjectPool RedfishObjectPool;
    public SimpleObjectPool IceObjectPool;
    public SimpleObjectPool MonsterObjectPool;
    public SimpleObjectPool InkObjectPool;
    public SimpleObjectPool SpeedUpObjectPool;
    public SimpleObjectPool UnbeatableObjectPool;

    public SimpleObjectPool Monster2ObjectPool;



    public float spawnXPosition = 10f;
    int dir = 1;
  
    float timeB = 0;
    float fishtimeG = 0;
    float fishtimeB = 0;
    float fishtimeR = 0;
    float Icetime = 0;
    float speedUpTime = 0;
    
    float fishGoldSpawnRate = 10;
    float fishBlueSpawnRate = 6;//12;
    float fishRedSpawnRate = 3;
    float iceSpawnRate = 10f;
    float speedUpSpawnRate;
    public bool isBossComming = false;
    int count = 0;
    // Use this for initialization

    private void Awake()
    {
        if (MemoryPool.memoryInstance == null)
            MemoryPool.memoryInstance = this;

        player = GameObject.Find("Player");
        speedUpSpawnRate = Random.Range(5f, 10f);
    }
    void Start ()
    {
       
       
        for (int i = 0; i < wallPoolSize; i++)
        {
           
            GameObject monster = MonsterObjectPool.GetObject();
            GameObject ink = InkObjectPool.GetObject();
            ink.transform.position = new Vector3(-100, -100, -100);

            monster.transform.position=new Vector3(spawnXPosition * (i + 1) + player.transform.position.x, 0.64f, -0.1f);


        }
	}

   public void Stage2()
    {
        
        for (int i = 0; i < wallPoolSize-10; i++)
        {

            GameObject monster = Monster2ObjectPool.GetObject();

            monster.transform.position = new Vector3(spawnXPosition*2 * (i + 1) + player.transform.position.x, 0.64f, -0.1f);


        }
        isBossComming = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!Pause.pause)
        {

        fishtimeB += Time.deltaTime;
        fishtimeR += Time.deltaTime;
        fishtimeG += Time.deltaTime;
        timeB += Time.deltaTime;
        Icetime += Time.deltaTime;
        speedUpTime += Time.deltaTime;
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            viewPos.y = 1f;
            Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);


            if (speedUpTime > speedUpSpawnRate && !isBossComming)
            {
                speedUpTime = 0;
                speedUpSpawnRate = Random.Range(5f, 10f);
                if (Random.Range(1, 3) == 1)
                {
                    GameObject Item = SpeedUpObjectPool.GetObject();
                    Item.transform.position = new Vector3(player.transform.position.x + spawnXPosition, WorldPos.y, -0.1f);
                }
                else
                {
                    GameObject Item = UnbeatableObjectPool.GetObject();
                    Item.transform.position = new Vector3(player.transform.position.x + spawnXPosition, WorldPos.y, -0.1f);
                }

                
            }
         if (Icetime > iceSpawnRate && !isBossComming)
        {
                Icetime = 0;
                GameObject newIce0 = IceObjectPool.GetObject();
                GameObject newIce1 = IceObjectPool.GetObject();
                GameObject newIce2 = IceObjectPool.GetObject();

                newIce0.transform.position = new Vector3(player.transform.position.x, WorldPos.y, -0.1f);
                newIce1.transform.position = new Vector3(player.transform.position.x+6, WorldPos.y, -0.1f);
                newIce2.transform.position = new Vector3(player.transform.position.x-6, WorldPos.y, -0.1f);
                newIce0.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
                newIce1.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
                newIce2.GetComponent<Rigidbody>().velocity = Vector2.down * Random.Range(.5f, 2f);
            }
        if (fishtimeB > fishBlueSpawnRate && !isBossComming)
        {
            fishtimeB = 0;
            GameObject newBluefish = BluefishObjectPool.GetObject();
            
            newBluefish.transform.position =new Vector3(spawnXPosition + player.transform.position.x, WorldPos.y, -0.1f);
        }

        if (fishtimeG > fishGoldSpawnRate && !isBossComming)
        {
            fishtimeG = Random.Range(0,2);
            GameObject newGoldfish = GoldfishObjectPool.GetObject();
            newGoldfish.transform.position = new Vector3(spawnXPosition + player.transform.position.x, WorldPos.y, -0.1f);
           
        }
        if (fishtimeR > fishRedSpawnRate && !isBossComming)
        {
            fishtimeR = Random.Range(0, 1);
            GameObject newRedfish = RedfishObjectPool.GetObject();
            newRedfish.transform.position = new Vector3(spawnXPosition + player.transform.position.x, WorldPos.y, -0.1f);
            

        }

        if (timeB > spawnRate && !isBossComming && count<15)
        {
            timeB = Random.Range(0, 1);
                if (MonsterObjectPool.inactiveInstances.Count > 0)
                {
                    GameObject monster = MonsterObjectPool.GetObject();
                    monster.transform.position = new Vector3(player.transform.position.x-(spawnXPosition*2)  , 0.64f, -0.1f);
                    count++;
                }
                else
                    return;
        }
        }
	}

  


    
}
