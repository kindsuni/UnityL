using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public GameObject minimap1;
    public GameObject minimap2;
    public Image ClearImage;
    public Image LoseImage;
    public GameObject Player;
    public Transform Boss;
    public Transform Boss2;
    public GameObject Gun;
    public GameObject Sword;
    private int stage;
    public Text Score;
    public int score = 0;
    bool active = true;

    // Use this for initialization

    private void Awake()
    {
        if (GameManager.gameManager == null)
            GameManager.gameManager = this;
       
        Player = GameObject.Find("Player");
        Sword = GameObject.Find("Sword");
        Gun = GameObject.Find("octopus");
        Gun.SetActive(false);
        minimap2.SetActive(false);
        ClearImage.gameObject.SetActive(false);
        LoseImage.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.pause)
        {
            if (Boss != null)
            {

                if (Vector3.Distance(Player.transform.position, Boss.position) < 8.0f)
                {
                    Boss.gameObject.SetActive(true);

                    Camera.main.GetComponent<SmoothCamera>().enabled = false;
                    MemoryPool.memoryInstance.isBossComming = true;

                }

              
            }
            if (Boss2 != null)
            {
                if (Vector3.Distance(Player.transform.position, Boss2.position) < 8.0f)
                {
                    Boss2.gameObject.SetActive(true);

                    Camera.main.GetComponent<SmoothCamera>().enabled = false;
                    MemoryPool.memoryInstance.isBossComming = true;

                }
            }
            
        }
        

    }
    void SetWeapon()
    {
        print("setWeapon");
        Player = GameObject.Find("Player");
        Sword = GameObject.Find("Sword");
        Gun = GameObject.Find("octopus");
        Sword.SetActive(!active);
        Gun.SetActive(active);
    }

    public void GetGun()
    {

        Gun.SetActive(active);
        Sword.SetActive(!active);
    }


    public void AddScore(int point)
    {
        score += point;
        Score.text = "Score :" + score.ToString();


    }

    public void nextStage()
    {
        //Player.GetComponent<PlayerMove>().nextStage = true;
        //Camera.main.transform.position = new Vector3(-16.75f, 9.99f, -15.38f);
        //Player.transform.position = new Vector3(-36.3f, 1.5f, -0.1f);
        Camera.main.GetComponent<SmoothCamera>().enabled = true;
      
        //Player.GetComponent<PlayerMove>().nextStage = false;
        stage++;
        if (stage == 1)
        {
            minimap1.SetActive(false);
            minimap2.SetActive(true);
            MemoryPool.memoryInstance.Stage2();
            
        }
        if (stage == 2)
            Clear();
        
       // SceneManager.LoadScene("PlayScene");
       
        // SetWeapon();

    }
    public void Clear()
    {

        ClearImage.gameObject.SetActive(true);
        Invoke("goClearScene", 3f);
    }
    public void Lose()
    {
        LoseImage.gameObject.SetActive(true);
    }
    void goClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }

}

