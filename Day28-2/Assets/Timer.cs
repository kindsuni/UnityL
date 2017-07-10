using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
   public static float t;
    public Accel A;
    public Accel B;

    public float fixedtime = 0.01f;
	// Use this for initialization
	void Start () {
        Time.fixedDeltaTime = fixedtime;


        float h = A.transform.position.x - B.transform.position.x;

        float a = B.acceleration - A.acceleration;
        float b = 2*(B.initialVelocity - A.initialVelocity);
        float c = -2*h;

        t = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
        print("The Time Is : " +t +" Secons");
	}
	
	
}
