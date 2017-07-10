using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicData : MonoBehaviour {

    public float v = 0f;    //마지막속도.
    public float a = -20f; //가속도.
    public float s = 3f; //이동 거리
    public float g = -9.8f; //중력
    public float fixedDeltaTime = 0.01f; //프레임.
	
	// Update is called once per frame
	void Update () {
        Time.fixedDeltaTime = fixedDeltaTime;
	}
}
