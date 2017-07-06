using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private float power;
    public float PowerPlus = 100.0f;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
        {
            power += PowerPlus * Time.deltaTime;
            Debug.Log(power);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Rigidbody Shot = GetComponent<Rigidbody>();
            Shot.AddForce(new Vector3(power, power, 0));
            power = 0.0f;
        }
        if(transform.position.y <-5.0f || transform.position.x>20.0f)
        {
            SceneManager.LoadScene("GameScene");
        }
	}
}
