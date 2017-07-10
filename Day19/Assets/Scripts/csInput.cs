using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class csInput : MonoBehaviour {
    Text txt;
    InputField input1;
    InputField input2;
    InputField input3;
    

	// Use this for initialization
	void Start () {
        txt = GameObject.Find("TextCenter").GetComponent<Text>();
        input1 = GameObject.Find("InputField1").GetComponent<InputField>();
        input2 = GameObject.Find("InputField2").GetComponent<InputField>();
        input3 = GameObject.Find("InputArea").GetComponent<InputField>();
	}
	public void ChangeValue()
    {
        txt.text = input1.text;
        if(txt.text.Length <4)
        {
            if(EditorUtility.DisplayDialog("알림" , "입력은 4자 이상 해주시기 바랍니다." , "확인"))
                {
                input1.Select();

            }


        }
        print("InputField1: " + input1.text);
        print("InputField2: " + input2.text);
        print("InputArea: " + input3.text);

    }
	
}
