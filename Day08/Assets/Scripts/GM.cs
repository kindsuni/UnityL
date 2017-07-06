using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youwon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;

    public static GM instance = null;

    private GameObject clonePaddle; //패들의 클론.
    //싱글턴.
    private void Awake() //게임 내에서 유일하게 존재해야 하는 경우사용(게임매니저, 로직 등등)
    {
        if (instance == null)//없으면 새로 만듬.
        {
            instance = this;
        }
        else if (instance != this) //이미 이전에 만들어져있으니 자기자신을 지우고 이전것을 사용.
        {
            Destroy(gameObject);
        }
        Setup(); //초기화 메서드.
    }
    public void Setup()
    { //패들을 생성      생성       오브젝트,  바인딩된오브젝트 위치,  회전각도만큼(indentity는 회전값없다).
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;//as 캐스팅(할필요없음)
        Instantiate(bricksPrefab, transform.position, Quaternion.identity); //블록 생성.
    }
    public void DestroyBrick()
    {
        bricks--;
        ChekGameOver();
    }
    public void LoseLife()
    {
        lives--; //목숨 줄이고
        livesText.text = "Lives : " + lives; //텍스트 값 갱신
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity); //이펙트 출력
        Destroy(clonePaddle); //패들 죽이고

        //호출한다.메서드 이름을    resetDelay시간뒤에 호출
        Invoke("SetupPaddle", resetDelay); //리셋
        ChekGameOver(); //게임오버 체크
    }
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }
    void ChekGameOver()
    {
        if(bricks<1)
        {
            youwon.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
        if(lives <1)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
    }
    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Play");
    }
}