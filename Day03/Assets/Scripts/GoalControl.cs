using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalControl : MonoBehaviour {
    private bool ishit = false;
    public float Goal_min = 5.0f;
    public float Goal_max = 10.0f;
	// Use this for initialization
	void Start () {

        float Gb = Random.Range(Goal_min, Goal_max);
        transform.position = new Vector3(Gb, -1.0f, 0.0f);
        
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        ishit = true;
        Debug.Log("Collision");
    }
    private void OnGUI()
    {
        if(ishit)
        {   
            GUI.Label(new Rect(Screen.width / 2, 80, 300, 100), "성공");
        }
    }
}
