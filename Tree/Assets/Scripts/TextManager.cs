using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {
    public GameObject energy; //현재 에너지
    public Text treeLevel; //나무 레벨
    public Text clickEnergy; //클릭당 에너지
    public Text needUp; //성장에 필요한 에너지
    public Text clickNeed;//클릭당 에너지를 업하기 위해 필요한 에너지.
	// Use this for initialization
	void Start () {
        energy.GetComponent<Text>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        
        energy.GetComponent<Text>().text ="Energy : "+ TreeController.energy +"";
        treeLevel.text = "트리 레벨 : " + TreeController.level;
        clickEnergy.text = "클릭당 에너지 : " + TreeController.enegyplus;
        clickNeed.text = "클릭 : " + TreeController.clickneed;
        needUp.text = "성장 : " + TreeController.need;

    }
}
