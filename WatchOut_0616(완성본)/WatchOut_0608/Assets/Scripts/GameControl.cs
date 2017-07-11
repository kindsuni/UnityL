using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	// 사운드 관리
	public AudioClip hpItemSound;
	public AudioClip bulletItemSound;
	public AudioClip buttonSound;
	public AudioClip playerHurt;
	public AudioClip playerDeath;
	public AudioClip AB_mobDeath;
	public AudioClip C_mobDeath;
	private AudioSource audioSound;

	// 애니메이션 관리
	public Animator kingAnim;
	
	// 속성 상태 관리
    public static int userLevel;            
    public static int kingHP;					// 경호대상 현재 체력
	public static int kingFullHP;				// 경호대상 최대 체력
    public static int playerBullet;				// 플레이어 현재 총알
	public static int playerFullBullet;			// 플레이어 최대 총알
    public static float limitTime;				// 남은 시간(타임어택)
	public static int itemHP;					// 체력 아이템 회복량
	public static int itemBullet;				// 총알 아이템 충전량

    public static bool isFail = false;			// 실패 엔딩
    public static bool isSuccess = false;		// 성공 엔딩

    public GameObject canvas;					// UI
    public GameObject uiControl;				// UI 관리
    public static bool isPopup = false;			// 팝업창 / true=띄움 false=안띄움
    
    public static GameControl instance = null;  // 싱글턴

    void Awake()
    {
		if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

		// Use this for initialization
	void Start()
	{
        userLevel = 0;
		limitTime = 999;    // 0 이하로 시작하면 Update()의 if (limitTime <= 0 || kingHP <= 0)... 코드 때문에 죽는 소리가 재생됨

		// 왕 HP, 경호원 총알 초기값, 최대값 설정
		kingHP = 70;
		kingFullHP = kingHP;
        playerBullet = 70;
		playerFullBullet = playerBullet;

		// 아이템 스탯 설정
		itemHP = kingFullHP / 3;
		itemBullet = playerFullBullet / 3;

		audioSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPopup = !isPopup;
        }

		if ((userLevel > 0 && !uiControl.GetComponent<UiControl>().GetIsCut()) && !isSuccess)
		{
			if (limitTime <= 0 || kingHP <= 0)
            {
                limitTime = 0;
                isFail = true;

				audioSound.clip = playerDeath;
				audioSound.Play();
            }
            else
            {
                limitTime -= Time.deltaTime;
                isFail = false;
            }
        }
    }

	public void ButtonSoundStart()
	{
		audioSound.clip = buttonSound;
		audioSound.Play();
	}

	public void HPItemSoundStart()
	{
		audioSound.clip = hpItemSound;
		audioSound.Play();
	}

	public void BulletItemSoundStart()
	{
		audioSound.clip = bulletItemSound;
		audioSound.Play();
	}

	public void PlayerHurtSoundStart()
	{
		audioSound.clip = playerHurt;
		audioSound.Play();
	}

	public void PlayerDeathSoundStart()
	{
		audioSound.clip = playerDeath;
		audioSound.Play();
	}

	public void AB_mobDeathSoundStart()
	{
		audioSound.clip = AB_mobDeath;
		audioSound.Play();
	}

	public void C_mobDeathSoundStart()
	{
		audioSound.clip = C_mobDeath;
		audioSound.Play();
	}
}
