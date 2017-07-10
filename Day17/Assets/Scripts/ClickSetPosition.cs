using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSetPosition : MonoBehaviour {
    //코루틴 할 스크립트 불러옴

    public PropertiesAndCoroutines coroutineScript;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        if(hit.collider.gameObject ==gameObject)
        {
            Vector3 newTarget = hit.point + new Vector3(0f, 0.5f, 0f);
            coroutineScript.Target = newTarget;
        }
    }
    
}
