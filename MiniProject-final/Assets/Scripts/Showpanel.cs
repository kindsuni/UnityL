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
   // public GameObject startbutton2panel;

    
    public GameObject pausePanel;
    public GameObject pausebuttonPanel;
    public GameObject restartquestionPanel;
    public GameObject exitquestionPanel;

    public GameObject Selectbutton;
    public GameObject Backbutton;

    //public GameObject fadeinpanel;
    //public GameObject fadeoutpanel;
    public GameObject deadpanel;
    public GameObject titleWindow;
   
    //public Image fadeinimage;
    //public Image fadeoutimage;

    public GameObject fadepanel;
    public Image fadeimage;

    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject starting;
    public GameObject readystartpanel;
    
    public static bool invokecancle = false;
    public static float fadeTime = 1f;
    
    Color colorToFadeTo;

    private void Awake()
    {
    }
    private void Start()
    {
        fadeimage.GetComponent<CanvasRenderer>().SetAlpha(1f);
        
        //Pause.pause = true;
      
        Allhide();
       if(SceneManager.GetActiveScene().name == "DeadScene")
        {
            showdeadPanel();
        }

    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        invokechek();
        senelevelcheck();
     
    }
    void invokechek()
    {
       
        if(Showpanel.invokecancle)
        {
           
            CancelInvoke();
            counthide();
        }
        
    }
    public void _three()
    {
        
        Invoke("Pausetrue", 0f);
        readystartpanel.SetActive(true);
        three.SetActive(true);
        two.SetActive(false);
        one.SetActive(false);
        starting.SetActive(false);

        //ready.SetActive(true)
        //go.SetActive(false);
        Invoke("_two", 1f);
    }
    public void _two()
    {
        three.SetActive(false);
        two.SetActive(true);
        one.SetActive(false);
        starting.SetActive(false);
        //ready.SetActive(false);
        //go.SetActive(true);
        //Invoke("hidegopanel", 1f);
        //Invoke("Pausefalse", 1f);
        Invoke("_one", 1f);

    }
    public void _one()
    {
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(true);
        starting.SetActive(false);
        Invoke("_start", 1f);
    }
    public void _start()
    {
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
        starting.SetActive(true);
        Invoke("_starting", 1f);
    }
    public void _starting()
    {
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
        starting.SetActive(false);
        hidereadystart();
        
        Invoke("Pausefalse", 2f);
    }
    public void counthide()
    {
        three.SetActive(false);
        two.SetActive(false);
        one.SetActive(false);
        starting.SetActive(false);
      invokecancle = true;
    }
    void hidereadystart()
    {

        readystartpanel.SetActive(false);
    }
    public void fadeIn()
    {
        print("FadeIn");
        FadesOnActive();
        fadeimage.GetComponent<CanvasRenderer>().SetAlpha(0f);
        colorToFadeTo = new Color(0f, 0f, 0f, 1f);
        fadeimage.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
        Invoke("fadeout", fadeTime);
        
        //Invoke("FadesinOffActive", fadeTime);
        
    }
    public void fadeout()
    {
        print("Fadeout");
        //R   G   B   투명도(0이면 투명, 1이면 불투명)
        colorToFadeTo = new Color(0f, 0f, 0f, 0f); //원하는 색상과 투명도.
        fadeimage.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
        Invoke("FadesOffActive", fadeTime);
    
        //오브젝트의 현재 색을 해당 컬러로 정한 시간동안, 타임스케일(T,F)에 상관없이,투명도(T,F) 바꿔주며 색깔을 서서히 바꿈.)
    }
    
  
    public void senelevelcheck()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            titleWindow.SetActive(true);
            TitleScene();

        }
        else if(SceneManager.GetActiveScene().name == "MenuScene")
        {
            titleWindow.SetActive(false);
            MenuScene();
        }
        else if(SceneManager.GetActiveScene().name == "PlayScene")
        {
            titleWindow.SetActive(false);
            PlayScene();
        }
        else if(SceneManager.GetActiveScene().name == "DeadScene")
        {
            titleWindow.SetActive(false);
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
        showtint();
       
       
    }
    public void HideOptionPanel()
    {
        
        
        optionPanel.SetActive(false);
        hidetint();
        
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
    //public void showstartbutton2()
    //{
    //    startbutton2panel.SetActive(true);
    //}
    //public void hidestartbutton2()
    //{
    //    startbutton2panel.SetActive(false);
    //}
    // ////////////////////////////////////////////////
    public void ShowPausePanel()
    {
       
        if (SceneManager.GetActiveScene().name != "TitleScene")
        {
        
        pausePanel.SetActive(true);
            showtint();
            Pausetrue();
            invokecancle = true;
        
        }
      
      
       
    }
    
    public void HidePausePanel()
    {

       // invokecancle = false;
        pausePanel.SetActive(false);
   
    }
    public void HidePausePanelB()
    {

        
        pausePanel.SetActive(false);
        hidetint();
        invokecancle = false;
        Invoke("Pausefalse", 3f);
    }
    // /////////////////////////////////////
    public void ShowExitQuestionPanel()
    {
        exitquestionPanel.SetActive(true);

    }
    public void HideExitQuestionPanel()
    {
        exitquestionPanel.SetActive(false);
        invokecancle = false;
    }
    public void ShowRestartQuestionPanel()
    {
        restartquestionPanel.SetActive(true);
    }
    public void HideRestartQuestionPanel()
    {
        restartquestionPanel.SetActive(false);
        invokecancle = false;
    }
    // //////////////////////////////
    //public void ShowChractorSelectPanel()
    //{
    //    chractorSelectPanel.SetActive(true);
    //}
    //public void HideChractorSelectPanel()
    //{
    //    chractorSelectPanel.SetActive(false);
    //}
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
       // hidestartbutton2();
        HidePausePanel();
        HideExitQuestionPanel();
        HideRestartQuestionPanel();
       // HideChractorSelectPanel();
        

    }
    void PauseBool()
    {
        if(Pause.pause ==false)
        {
            Pause.pause = true;
        }
        else
        {
            Pause.pause = false;
        }
    }
   public  void Pausefalse( )
    {
       
        Pause.pause = false;
       
        

    }
    void Pausetrue()
    {
        Pause.pause = true;

    }
    void showselectbutton()
    {
       Selectbutton.SetActive(true);
    }

    void hideselectbutton()
    {
        Selectbutton.SetActive(false);
    }
    void showgopanel()
    {
        //go.SetActive(true);
    }
    void hidegopanel()
    {
        //go.SetActive(false);
    }
   public  void showtint()
    {
        optionTint.SetActive(true);
    }
   public  void hidetint()
    {
        optionTint.SetActive(false);
    }
    public void TitleScene()
    {
       
        showstartbutton();
        showoptionbutton();

        HidePausePanel();
        //hidestartbutton2();       
        //HideExitQuestionPanel();
        HideRestartQuestionPanel();
       // HideChractorSelectPanel();
        HideBackbuttonPanel();
        hidepausebutton();
        hidedeadPanel();
        hideselectbutton();
        hidegopanel();
        
    }
    public void MenuScene()
    {
        
        hidestartbutton();
        hideoptionbutton();

        //showstartbutton2();
        ShowBackbuttonPanel();
        showselectbutton();
       // ShowChractorSelectPanel();
        HideExitQuestionPanel();
        HideRestartQuestionPanel();
        hidepausebutton();
        hidedeadPanel();
       
    }
    public void PlayScene()
    {
        hideselectbutton();
        hidestartbutton();
       // hidestartbutton2();
        HideBackbuttonPanel();
        hideoptionbutton();
       // HideChractorSelectPanel();     
        hidedeadPanel();
        showpausebutton();
        
    }
    public void DeadScene()
    {
        showdeadPanel();
        hideselectbutton();
        hidestartbutton();
       // hidestartbutton2();
        HidePausePanel();
        hideoptionbutton();
        hidepausebutton();

    }
}
