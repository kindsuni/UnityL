 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour {
    public float enemy_speed = 20;
    private void Update()
    {
        transform.Translate(Vector3.forward * enemy_speed * Time.deltaTime);
    }
}
