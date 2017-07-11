using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour {
    Slider miniMap;
    public Transform startPos;
    public Transform endPos;
    public Transform playerX;
    private float currentX;
   
    private void Start()
    {
        miniMap=GameObject.Find("MiniMap").GetComponentInChildren<Slider>();
       
    }

    private void Update()
    {
     //   float ratio = (startPos.position.x- endPos.position.x) *(startPos.position.x- playerX.position.x) /100f;
        miniMap.minValue = startPos.position.x;
        miniMap.maxValue = endPos.position.x;
        miniMap.value = playerX.position.x;
      
    }
}
