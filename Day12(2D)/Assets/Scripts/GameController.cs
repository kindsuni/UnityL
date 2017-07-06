using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public static bool isready = true;
    public Text ScoreText;
    public int Score;

    
    public GameObject GameOverText;
    public bool gameOver = false;
    public float ScrollSpeed = -1.5f;
    
    // Use this for initialization
    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
        
    }


    // Update is called once per frame
    void Update () {
        ReadyCheck();
        if(isready ==false)
        {
            gameObject.GetComponent<ColumnPool>().enabled = true;
            Invoke("Pool", 1.7f);
        }
        else
        {
            gameObject.GetComponent<ColumnPoo>().enabled = false;
            gameObject.GetComponent<ColumnPool>().enabled = false;
        }
     
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
   public void BirdScored()
    {
        if(gameOver)
        { return; }
        Score++;
        ScoreText.text = "Score : " + Score.ToString();
    }
   public void BirdDied()
    {
        GameOverText.SetActive(true);
        gameOver = true;
        isready = true;
    }
    public void ReadyCheck()
    {
        if (Bird.Ready ==false)
        {
           
            isready = false;
        }
        else
        {
            isready = true;
        }
      
    }
    public void Pool()
    {
        gameObject.GetComponent<ColumnPoo>().enabled = true;
    }
   

}
