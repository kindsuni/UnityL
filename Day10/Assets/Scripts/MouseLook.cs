using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseMoveX = Input.GetAxis("Mouse X"); //마우스 X방향
        float mouseMoveY = Input.GetAxis("Mouse Y");//마우스 Y방향 입력받음.

        rotationX += mouseMoveX * sensitivity * Time.deltaTime;
        rotationY += mouseMoveY * sensitivity * Time.deltaTime;

        if (rotationY > 45f)
        {
            rotationY = 45f;
        }
        if(rotationY <-20f)
        {
            rotationY = -20f;
        }
        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0f);
    }
}
