using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCoroutine3 : MonoBehaviour {

    public string url;
    WWW www;

    private IEnumerator Start()
    {
        www = new WWW(url);
        StartCoroutine("CheckProgress");
        yield return www;
        Debug.Log("Download Completed");

    }
    IEnumerator CheckProgress()
    {
        Debug.Log("A: " + www.progress);
        while (!www.isDone)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("B : " + www.progress);
        }
    }


}
