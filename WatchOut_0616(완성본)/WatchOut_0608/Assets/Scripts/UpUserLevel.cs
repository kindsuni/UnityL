using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpUserLevel : MonoBehaviour {

	GameControl GM;

	private void Start()
	{
		GM = GameObject.Find("GameMaster").GetComponent<GameControl>();
	}

	public void UpUserLv()
    {
		GM.ButtonSoundStart();
		GameControl.userLevel++;
		if (GameControl.userLevel == 4)
		{
			GameControl.userLevel = 0;
		}
        SceneManager.LoadScene(GameControl.userLevel);
    }
}
