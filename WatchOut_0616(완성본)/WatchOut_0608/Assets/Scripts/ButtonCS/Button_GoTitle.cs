using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_GoTitle : MonoBehaviour {

	public GameObject popup;
    public GameObject underBar;

	public void GoTitle()
    {
		GameControl.instance.ButtonSoundStart();
		GameControl.isSuccess = false;
        GameControl.isFail = false;
        GameControl.limitTime = 6.0f;
        GameControl.userLevel = 0;
        GameControl.playerBullet = GameControl.playerFullBullet;
        GameControl.kingHP = GameControl.kingFullHP;
        Cursor.visible = true;
        popup.SetActive(false);
        underBar.SetActive(false);
        GameControl.isPopup = false;
        SceneManager.LoadScene(0);
    }
}
