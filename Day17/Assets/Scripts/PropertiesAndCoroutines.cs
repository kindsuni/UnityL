using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesAndCoroutines : MonoBehaviour {
    public float smoothing = 7f; //이동속도.
    public Vector3 Target 
    {
        get { return this.Target; }
        set
        {
            this.target = value;

            StopCoroutine("Movement");
            StartCoroutine("Movement", this.target);
        }
    }
    private Vector3 target;

    IEnumerator Movement (Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {                                     //Vector3 a       Vector3 b, float t
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime/ Vector3.Distance(transform.position , target));
            //                                  현재 위치      ,  타겟위치, 이동
           // transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
            yield return null;
        }
    }
}
