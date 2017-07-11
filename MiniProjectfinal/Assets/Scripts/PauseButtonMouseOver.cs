using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonMouseOver : MonoBehaviour {
    public static bool pauseButtonMouseover = false;
    // Use this for initialization
    private void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        print("Mouse On");
        pauseButtonMouseover = true;
    }
    private void OnMouseExit()
    {
        print("Mouse Exit");
        pauseButtonMouseover = false;
    }
    
}
