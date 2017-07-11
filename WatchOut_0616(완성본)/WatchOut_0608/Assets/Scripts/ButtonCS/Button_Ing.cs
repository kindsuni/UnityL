using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Ing : MonoBehaviour {

    public GameObject popup;

	public void IngGame()
    {
		GameControl.instance.ButtonSoundStart();
		popup.SetActive(false);
        GameControl.isPopup = false;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }
}
