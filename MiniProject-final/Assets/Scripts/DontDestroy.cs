﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    private static DontDestroy instanceRef;

    private void Awake()
    {
        if(instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    
	
}
