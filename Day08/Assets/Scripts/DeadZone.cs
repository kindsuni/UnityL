using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    { //볼이 물 밑으로 떨어지면 한번 충돌 판정하여 메소드 실행
        GM.instance.LoseLife();
    }
    // Use this for initialization

}
