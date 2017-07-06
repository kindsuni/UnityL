using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬을 변경하는 엔진을 씀.
public class TitleScene : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Prifeb");
        }
	}
    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 128, 32), "Title");
    }
}
