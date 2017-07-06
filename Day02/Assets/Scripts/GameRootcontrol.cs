using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRootcontrol : MonoBehaviour {

    public GameObject prefab = null; //UI용 프리팹
    private AudioSource audio;
    public AudioClip jumpSound;

    public Texture2D icon = null;
    public static string mes_text = "게임 아카데미";
    
	// Use this for initialization
	void Start () {
        audio = gameObject.AddComponent<AudioSource>(); //스타트 될때 AddComponent를 추가함(오디오 컴포넌트를).
        audio.clip = jumpSound;
        audio.loop = false; //반복 플레이
        audio.spatialBlend = 0.0f; //3D사운드를 1.0으로 하면 3D사운드를 씀.(카메라 거리에 따라 소리가 작거나 커짐)
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            GameObject go = GameObject.Instantiate(prefab); ////X           Y            Z
            go.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 1.0f, Random.Range(-2.0f, 2.0f));
            // 랜덤을 -2~2까지
            audio.Play();
        }
        if(Input.GetKey(KeyCode.D))
        {
            GameObject go = GameObject.Find("unito(Clone)");
            GameObject.Destroy(go);
        }
        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("SceneTransition");
        }

	}
    private void OnGUI()
    {                       //사각 박스(Rect) x,y 포인트 기준으로 가로,세로지정.
                                  //현재 스크린(Screen.width)의 가로크기 정중앙위치 
        GUI.DrawTexture(new Rect(Screen.width / 2, 64, 64, 64), icon);
        GUI.Label(new Rect(Screen.width / 2, 128, 128, 32), mes_text);
    }
}
