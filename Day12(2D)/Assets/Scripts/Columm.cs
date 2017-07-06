using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columm : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bird>() != null)
        GameController.Instance.BirdScored();
    }
}
