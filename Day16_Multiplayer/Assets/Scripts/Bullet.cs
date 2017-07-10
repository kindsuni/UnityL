﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>(); //
        if(health != null) //if (health)
        {
            health.TakeDemage(10);
        }
        Destroy(gameObject);
    }
}