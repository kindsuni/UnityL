using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour {

    public GameObject backG;
    public GameObject[] cut;
	public GameObject cut00enter;
	public GameObject underBar;
    public GameObject ex;
    public GameObject popup;					// 인게임 버튼 활성화 X
    public GameObject upG;
    public GameObject gameOver;
    public GameObject gameClear;
    public GameObject title;					// 인게임 버튼 활성화 X

	public GameObject kingFaceImage1;			// 왕 얼굴 이미지
	public GameObject kingFaceImage2;			// 왕 얼굴 이미지
    public GameObject kingHP;			 
    public Text limitTime;
    public Text bullet;
	public GameObject[] bulletImage;			// 총알 개수 이미지

    private bool okEx;							// true=읽음 false=안읽음
	private bool isCut = false;					// true=띄워짐 false=안띄움
	private static bool onlyFirstEx = true;
	private int min;
	private int sec;
	private AudioSource buttonSound;

	public static UiControl instance = null;	// 싱글턴

	void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		KingHpBar();

		LimitTimer();

		BulletManagine();

        if (GameControl.isFail)
        {
            GameControl.isFail = true;
            GameOver();
        }
        else if ((KingRoam.isGoal && GameControl.userLevel == 3) || GameControl.isSuccess)
        {
            GameControl.isSuccess = true;
            GameClear();
        }
        else if ((KingRoam.isGoal && GameControl.userLevel < 3) || isCut)
        {
            isCut = true;
            IsGoalIn();
        }
        else
        {
            if (GameControl.userLevel > 0)
            {   
				//Scene00 UI 끄기
                backG.SetActive(false);
                upG.SetActive(false);
                cut[GameControl.userLevel-1].SetActive(false);
                gameOver.SetActive(false);
                gameClear.SetActive(false);
                title.SetActive(false);
			}
            switch (GameControl.userLevel)
            {
                case 1:
                    UI01(); // Ex InUI Popup Cut[1]
					break;
                case 2:
                    UI02(); //  InUI Popup cut[2]
                    break;
                case 3:
                    UI03(); //  InUI Popup Clear
                    break;
                default:
                    UI00(); // cut[0] Title 
                    break;
            }
        }
	}

    public bool GetIsCut()
    {
        return this.isCut;
    }

	void UI00() // cut[0] Title ***
	{
		backG.SetActive(true);
		Time.timeScale = 1.0f;
		cut[GameControl.userLevel].SetActive(true);
		if (cut00enter.GetComponent<Image>().color.a == 1.0f)
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				buttonSound.Play();
				title.SetActive(true);
			}
		}
	}

	void UI01() // Ex InUI Popup Cut[1]
    {
		popup.SetActive(GameControl.isPopup);
        
        if (onlyFirstEx == true)
        {
            if (ex.GetComponent<Image>().enabled == false)
            {
                ex.GetComponent<Image>().enabled = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                if (Input.anyKeyDown)
                {
                    ex.GetComponent<Image>().enabled = false;
                    Time.timeScale = 1.0f;
                    onlyFirstEx = false;
                }
            }
        }
        else
        {
            if (GameControl.isPopup)
            {
				Time.timeScale = 0.0f;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                Cursor.visible = false;
            }
        }
        
        underBar.SetActive(true);
    }

    void UI02() // InUI Popup Cut[2]
    {
		popup.SetActive(GameControl.isPopup);
        if (GameControl.isPopup)
        {
            Time.timeScale = 0.0f;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.visible = false;
        }
        underBar.SetActive(true);
    }

    void UI03() // InUI Popup
    {

		popup.SetActive(GameControl.isPopup);
        if (GameControl.isPopup)
        {
            Time.timeScale = 0.0f;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.visible = false;
        }
        underBar.SetActive(true);
    }
    
    void IsGoalIn()
    {

		underBar.SetActive(false);
        upG.SetActive(true);

        if (upG.GetComponent<Image>().color.a == 1)
        {
            cut[GameControl.userLevel].SetActive(true);
            if (cut[GameControl.userLevel].GetComponent<Image>().color.a == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
					buttonSound.Play();
					if (upG.GetComponent<Image>().color.a == 1)
                    {
                        isCut = false;
                        GameControl.userLevel++;
                        SceneManager.LoadScene(GameControl.userLevel);
                    }
                }
            }
        }
    }

    void GameOver()
	{ 
		underBar.SetActive(false);
        upG.SetActive(GameControl.isFail);

        if (upG.GetComponent<Image>().color.a == 1)
        {
            gameOver.SetActive(GameControl.isFail);
            if (gameOver.GetComponent<Image>().color.a == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
					buttonSound.Play();

					GameControl.isFail = false;
                    GameControl.limitTime = 30.0f;
                    GameControl.userLevel = 0;
                    GameControl.playerBullet = GameControl.playerFullBullet;
                    GameControl.kingHP = GameControl.kingFullHP;
                    Cursor.visible = true;
                    GameControl.isPopup = false;
                    gameOver.SetActive(false);
                    SceneManager.LoadScene(GameControl.userLevel);
                }
            }
        }
    }

    void GameClear()
    {
		underBar.SetActive(false);
        upG.SetActive(GameControl.isSuccess);
            
        if (upG.GetComponent<Image>().color.a == 1)
        {
            gameClear.SetActive(GameControl.isSuccess);
            if (gameClear.GetComponent<Image>().color.a == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
					buttonSound.Play();

					GameControl.isSuccess = false;
                    GameControl.limitTime = 30.0f;
                    GameControl.userLevel = 0;
                    GameControl.playerBullet = GameControl.playerFullBullet;
                    GameControl.kingHP = GameControl.kingFullHP;
                    Cursor.visible = true;
                    GameControl.isPopup = false;
                    gameClear.SetActive(false);
                    SceneManager.LoadScene(GameControl.userLevel);
                }
            }
        }
    }

	void LimitTimer()
	{
		min = Mathf.FloorToInt(GameControl.limitTime / 60.0f);
		sec = Mathf.RoundToInt(GameControl.limitTime % 60.0f);
		if(min == 0 && sec <= 20)
		{
			limitTime.text = min.ToString("D2") + " : " + sec.ToString("D2");
			limitTime.color = Color.red;
		}
		limitTime.text = min.ToString("D2") + " : " + sec.ToString("D2");
	}

	void KingHpBar()
	{
		kingHP.GetComponentInChildren<Text>().text = GameControl.kingHP.ToString();

		kingHP.GetComponent<Image>().fillAmount = GameControl.kingHP / (float)GameControl.kingFullHP;

		if (kingHP.GetComponentInChildren<Image>().fillAmount <= 0.3f)
		{
			kingFaceImage1.GetComponent<Image>().enabled = false;
			kingFaceImage2.GetComponent<Image>().enabled = true;
		}
		else
		{
			kingFaceImage1.GetComponent<Image>().enabled = true;
			kingFaceImage2.GetComponent<Image>().enabled = false;
		}
	}
	
	void BulletManagine()
	{
		// 조건문의 비교 수치에 따라 보이는 이미지가 다름
		// 비율에 따라 보이는 이미지가 다르게 하는 것도 가능

		bullet.text = GameControl.playerBullet.ToString();

		if(GameControl.playerBullet >= 60)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 1].GetComponent<Image>().enabled = true;
		}
		else if(GameControl.playerBullet >= 50)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 2].GetComponent<Image>().enabled = true;
		}
		else if (GameControl.playerBullet >= 40)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 3].GetComponent<Image>().enabled = true;
		}
		else if (GameControl.playerBullet >= 30)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 4].GetComponent<Image>().enabled = true;
		}
		else if (GameControl.playerBullet >= 20)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 5].GetComponent<Image>().enabled = true;
		}
		else if (GameControl.playerBullet >= 10)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 6].GetComponent<Image>().enabled = true;
		}
		else if (GameControl.playerBullet > 0)
		{
			for (int i = 0; i < bulletImage.Length; i++)
			{
				bulletImage[i].GetComponent<Image>().enabled = false;
			}
			bulletImage[bulletImage.Length - 7].GetComponent<Image>().enabled = true;
		}
		else // GameControl.playerBullet <= 0
		{

		}
	}

	void PauseAndMousePointerControllByEscape()
	{
		if (GameControl.isPopup == true && Cursor.visible == false)
		{
            Time.timeScale = 0.0f;
			Cursor.visible = true;
		}
		else if (GameControl.isPopup == false && Cursor.visible == true)
		{
            Time.timeScale = 1.0f;
			Cursor.visible = false;
		}
	}

}
