using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour {
    
   public  Image _fade;
    Color colorToFadeTo;
    public float fadeTime = 1f;
    // Use this for initialization
    void Start () {
        _fade.GetComponent<CanvasRenderer>().SetAlpha(1f);
        FadesOffActive();
    }
    public void fadeIn()
    {
        print("FadeIn");
        FadesOnActive();
        _fade.GetComponent<CanvasRenderer>().SetAlpha(0f);
        colorToFadeTo = new Color(0f, 0f, 0f, 1f);
        _fade.CrossFadeColor(colorToFadeTo, fadeTime, true, true);

        Invoke("loadScene", fadeTime);
        //Invoke("FadesinOffActive", fadeTime);

    }
    void FadesOnActive()
    {
        _fade.gameObject.SetActive(true);
    }
    void FadesOffActive()
    {
        _fade.gameObject.SetActive(false);
    }
    void loadScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
