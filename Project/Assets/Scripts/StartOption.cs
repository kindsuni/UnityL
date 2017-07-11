using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartOption : MonoBehaviour {
   
    public bool changeScenes;

    private Showpanel showPanels;
    public bool inMainMenu = true;
   
    
    private void Awake()
    {
        showPanels = GetComponent<Showpanel>();
       
    }
    private void Start()
    {
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
        Invoke("GoPlay", Showpanel.fadeTime);

    }
    public void ClickedDeadScene()
    {
        Invoke("GoDeadscene", Showpanel.fadeTime);
    }
    void GoTitle()
    {
        int title = 0;
        SceneManager.LoadScene(title);
        
    }
    void GoMenu()
    {
        int menu = 1;
        SceneManager.LoadScene(menu);
        
    }
    void GoPlay()
    {
        Pause.pause = false;
        int play = 2;
        SceneManager.LoadScene(play);
        
    }
    void GoDeadscene()
    {
        int dead = 3;
        SceneManager.LoadScene(dead);
    }

    
}
