using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraManager : MonoBehaviour {
    public Camera MainC;
    public Camera SubC;

    // Use this for initialization
    private void Awake()
    {
      
    }
    void  Start () {
        Camera[] came = Camera.allCameras;
        MainC = came[0];
        SubC = came[1];

    }
	public void MainCameraOn()
    {
 
        MainC.enabled = true;
        SubC.enabled = false;
    }
    public void SubCameraOn()
    {
        MainC.enabled = false;
        SubC.enabled = true;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
