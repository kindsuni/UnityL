using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float paddleSpeed = 20f;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed*Time.deltaTime);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f); //Clamp(벗어나지 말아야할 범위)
        transform.position = playerPos;
	}
}
