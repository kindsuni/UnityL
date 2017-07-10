using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canDamage : MonoBehaviour {
    public bool enableDamage = false;

    public void EnableDetectDamage()
    {
        print("Enabled: " + name);
        enableDamage = true;
    }


    public void DisableDetectDamage()
    {
        print("disabled: " + name);
        enableDamage = false;
    }
}
