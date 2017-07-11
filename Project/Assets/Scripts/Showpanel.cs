using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Showpanel : MonoBehaviour {

    public GameObject optionPanel;
    public GameObject optionbuttonpanel;
    public GameObject optionTint;

    public GameObject startbuttonpanel;
    public GameObject startbutton2panel;

    
    public GameObject pausePanel;
    public GameObject pausebuttonPanel;
    public GameObject restartquestionPanel;
    public GameObject exitquestionPanel;

    public GameObject chractorSelectPanel;
    public GameObject Backbutton;

    //public GameObject fadeinpanel;
    //public GameObject fadeoutpanel;
    public GameObject fadepanel;
    public GameObject deadpanel;
    public GameObject titleWindow;
   
    //public Image fadeinimage;
    //public Image fadeoutimage;

    public Image fadeimage;

    public static float fadeTime = 1f;
    
    Color colorToFadeTo;
    private void Awake()
    {
       
    }
    private void Start()
    {
        fadeimage.GetComponent<CanvasRenderer>().SetAlpha(1f);
        
      
        Allhide();
       

    }
    private void Update()
    {
        senelevelcheck();
    }
    public void fadeout()
    {
        
        //R   G   B   투명도(0이면 투명, 1이면 불투명)
        colorToFadeTo = new Color(0f, 0f, 0f, 0f); //원하는 색상과 투명도.
        fadeimage.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
        Invoke("FadesOffActive", fadeTime);
    
        //오브젝트의 현재 색을 해당 컬러로 정한 시간동안, 타임스케일(T,F)에 상관없이,투명도(T,F) 바꿔주며 색깔을 서서히 바꿈.)
    }
    public void fadeIn()
    {
        
        FadesOnActive();
        fadeimage.GetComponent<CanvasRenderer>().SetAlpha(0f);
        colorToFadeTo = new Color(0f, 0f, 0f, 1f);
        fadeimage.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
        Invoke("fadeout", fadeTime);
        
        //Invoke("FadesinOffActive", fadeTime);
        
    }
    
    bool pause = false;
    public void senelevelcheck()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {

            TitleScene();

        }
        else if(SceneManager.GetActiveScene().name == "MenuScene")
        {
            MenuScene();
        }
        else if(SceneManager.GetActiveScene().name == "PlayScene")
        {
            PlayScene();
        }
        else if(SceneManager.GetActiveScene().name == "DeadScene")
        {
            DeadScene();
        }
    }
    
    //public GameObject optionPanel;
    //public GameObject optionbuttonpanel;
    //public GameObject optionTint;

    //public GameObject startbuttonpanel;
    //public GameObject startbutton2panel;


    //public GameObject pausePanel;
    //public GameObject pausebuttonPanel;
    //public GameObject restartquestionPanel;
    //public GameObject exitquestionPanel;
    public void showoptionbutton()
    {
        optionbuttonpanel.SetActive(true);
        
    }
    public void hideoptionbutton()
    {
        optionbuttonpanel.SetActive(false);
    }
    public void ShowOptionPanel()
    {
        optionPanel.SetActive(true);
        optionTint.SetActive(true);
    }
    public void HideOptionPanel()
    {
        print("hide option");
        optionPanel.SetActive(false);
        optionTint.SetActive(false);
    }
    // /////////////////////////////////////////////
    public void showstartbutton()
    {
        startbuttonpanel.SetActive(true);
    }
    public void hidestartbutton()
    {
        startbuttonpanel.SetActive(false);
    }
    public void showstartbutton2()
    {
        startbutton2panel.SetActive(true);
    }
    public void hidestartbutton2()
    {
        startbutton2panel.SetActive(false);
    }
    // ////////////////////////////////////////////////
    public void ShowPausePanel()
    {
        if (SceneManager.GetActiveScene().name != "TitleScene")
        {

         print("No Title");
        pause = true;
        pausePanel.SetActive(true);
       optionTint.SetActive(true);
        Invoke("PauseBool", 0f);
        }

        
    }
    
    public void HidePausePanel()
    {

        
        pausePanel.SetActive(false);
       
        
    }
    public void HidePausePanelB()
    {

        pause = false;
        pausePanel.SetActive(false);
        optionTint.SetActive(false);
        Invoke("PauseBool", 3f);
    }
    // /////////////////////////////////////
    public void ShowExitQuestionPanel()
    {
        exitquestionPanel.SetActive(true);

    }
    public void HideExitQuestionPanel()
    {
        exitquestionPanel.SetActive(false);
        optionTint.SetActive(false);

    }
    public void ShowRestartQuestionPanel()
    {
        restartquestionPanel.SetActive(true);
    }
    public void HideRestartQuestionPanel()
    {
        restartquestionPanel.SetActive(false);
        optionTint.SetActive(false);
    }
    // //////////////////////////////
    public void ShowChractorSelectPanel()
    {
        chractorSelectPanel.SetActive(true);
    }
    public void HideChractorSelectPanel()
    {
        chractorSelectPanel.SetActive(false);
    }
    // //////////////////////////
    public void ShowBackbuttonPanel()
    {
        Backbutton.SetActive(true);
    }
    public void HideBackbuttonPanel()
    {
        Backbutton.SetActive(false);
    }
    public void FadesOnActive()
    {
        fadepanel.SetActive(true);
    }
    public void FadesOffActive()
    {
        fadepanel.SetActive(false);
    }
    public void showpausebutton()
    {
        pausebuttonPanel.SetActive(true);
    }
   public void  hidepausebutton()
    {
        pausebuttonPanel.SetActive(false);
    }
    public void showdeadPanel()
    {

        if (SceneManager.GetActiveScene().name == "DeadScene")
        {
        deadpanel.SetActive(true);

        }
        else
            deadpanel.SetActive(false);
    }
    public void hidedeadPanel()
    {
        deadpanel.SetActive(false);
    }
    public void Allhide()
    {
        
        HideOptionPanel();
        hidestartbutton();
        hidestartbutton2();
        HidePausePanel();
        HideExitQuestionPanel();
        HideRestartQuestionPanel();
        HideChractorSelectPanel();
        

    }
    void PauseBool( )
    {
        if(pause)
        {
        Pause.pause = true;

        }
        else
        {
        Pause.pause = false;

        }

    }
    public void TitleScene()
    {
        print("TitleScene");
        showstartbutton();
        showoptionbutton();

        HidePausePanel();
        hidestartbutton2();       
        HideExitQuestionPanel();
        HideRestartQuestionPanel();
        HideChractorSelectPanel();
        HideBackbuttonPanel();
        hidepausebutton();
        hidedeadPanel();
        GameObject.Find("TitleWindow").SetActive(true);
    }
    public void MenuScene()
    {
        print("MenuSecen");
        hidestartbutton();
        hideoptionbutton();

        showstartbutton2();
        ShowBackbuttonPanel();
        ShowChractorSelectPanel();
        HideExitQuestionPanel();
        HideRestartQuestionPanel();
        hidepausebutton();
        hidedeadPanel();
        GameObject.Find("TitleWindow").SetActive(false);
    }
    public void PlayScene()
    {
        print("PlayScene");
        hidestartbutton();
        hidestartbutton2();
        HideBackbuttonPanel();
        hideoptionbutton();
        HideChractorSelectPanel();     
        showpausebutton();
        hidedeadPanel();
        GameObject.Find("TitleWindow").SetActive(false);
    }
    public void DeadScene()
    {
        
        print("DeadSene");
        hidestartbutton();
        hidestartbutton2();
        HidePausePanel();
        hideoptionbutton();
        hidepausebutton();

    }
}
