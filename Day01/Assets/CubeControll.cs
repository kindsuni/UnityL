using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControll : MonoBehaviour {

    // Use this for initialization
    private Vector3 dir = Vector3.forward;
    
    public int yRotation = 60;
    public int yMiRotation = -60;
    private Vector3 rollforward = Vector3.right;
    private Vector3 rollbackward = Vector3.left;
    public float rollspeed = 300;
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) //A키를 누르면,
        {
            dir = Quaternion.Euler(0, yMiRotation * Time.deltaTime, 0) * dir; //벡터에 z축(dir)을곱하면 회전된 방향이 나옴.
            transform.Rotate(Vector3.up, yMiRotation * Time.deltaTime,Space.World);//Y축 기준으로 로테이션함.
            //up은 Y축 0,1,0임.
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir = Quaternion.Euler(0, yRotation * Time.deltaTime, 0) * dir;
            transform.Rotate(Vector3.up, yRotation * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(dir.normalized * 7.0f * Time.deltaTime, Space.World);
            transform.Rotate(rollforward.normalized * rollspeed * Time.deltaTime, Space.Self);
            
            //normalized =벡터의 길이를 1로 만들어준다. 유닛 벡터.
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(dir.normalized * -7.0f * Time.deltaTime, Space.World);
            transform.Rotate(rollbackward.normalized * rollspeed * Time.deltaTime, Space.Self);
        }
        /*
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.rotation *= Quaternion.Euler(10, 0, 0);

            gameObject.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f), Space.Self);
        }
        */

        /*
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0.0f, 0.0f, -0.1f);

            
        }
        Debug.Log(Input.mousePosition);
 */   
    }
}
