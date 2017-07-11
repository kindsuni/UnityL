using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartOption : MonoBehaviour {
   
    public bool changeScenes;
    public static bool playbuttonclick=false;
    private Showpanel showPanels;
    public bool inMainMenu = true;
   
    
    private void Awake()
    {
        showPanels = GetComponent<Showpanel>();
       
    }
    private void Start()
    {
        print("load Scene");
        showPanels.Allhide();
        if(SceneManager.GetActiveScene().name =="TitleScene")
        {
            showPanels.FadesOnActive();
            showPanels.fadeout();
        }
        
    }
    private void Update()
    {
      
      //  showpanel.imageFade(fade);
    }
    
  
    
   public void fadein()
    {
        showPanels.fadeIn();
    }
    public void fadeout()
    {
        showPanels.fadeout();
    }
    public void ClickedTitleBotton()
    {
        
        Invoke("GoTitle", Showpanel.fadeTime);
        
    }
    public void ClickedMenuBotton()
    {
       
       
            Invoke("GoMenu", Showpanel.fadeTime);


    }
    public void ClickedPlayBotton()
    {
        playbuttonclick = true;
        Invoke("GoPlay", Showpanel.fadeTime);
        
    }
    public void ClickedDeadScene()
    {
        Invoke("GoDeadscene", Showpanel.fadeTime);
    }
    void GoTitle()
    {
        int title = 1;
        SceneManager.LoadScene(title);
        
    }
    void GoMenu()
    {
        int menu = 2;
        SceneManager.LoadScene(menu);
        
    }
    void GoPlay()
    {
        Pause.pause = false;
        int play = 3;
        SceneManager.LoadScene(play);
        


    }
    void GoDeadscene()
    {
        int dead = 4;
        SceneManager.LoadScene(dead);
    }
    public void GoPlayed()
    {
        Pause.pause = true;
        Invoke("invokeplay", 0f);

    }
    void invokeplay()
    {
        showPanels._three();
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
