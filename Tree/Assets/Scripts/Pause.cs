using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public static bool pause = false;
    
	public void setpause()
    {
        StartCoroutine(sd());
    }
        IEnumerator sd()
        {
        if( pause== false)
        {
            pause = !pause;

            yield return null;

        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            pause = !pause;
        }

        }
}
