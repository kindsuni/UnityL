using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class RegExp : MonoBehaviour {
    string text = "Unity, C#, Regexp, Javascript, C++, Code ";
    string pattern = @"C\+\+"; //@꼭 넣어야함. 이스케이프 시켜줌.
    string pattern2 = @"(?=.*[a-zA-Z])(?=.*[!@#$%^*+=-])(?=.*[0-9]).{6,12}"; //*는 없거나 있거나찾음.
    //6글자~12글자안에 0~9숫자와 특수문자와 알파벳을가진 문자열을 찾음.

    // Use this for initialization
    void Start () {
        if(Regex.IsMatch(text,pattern,RegexOptions.IgnoreCase))
        {
            print("Found");
        }
        else
        {
            print("Not Found");
        }
       if(Regex.IsMatch(text,pattern2,RegexOptions.IgnoreCase))
        {
            print("Found PW");
        }
        else
        {
            print("Not Found PW");
        }
        //"UnityC#RegexpJavascriptC++Code" 결과가 나옴.
        string result = Regex.Replace(text, @", ", ""); //text의 콤마스페이스를찾아서 ""(지운다)
        print(result);

        print(Regex.Match(text, @" \w+"));

        MatchCollection matches = Regex.Matches(text, @"\b\w+[+#]*"); //공백이있는 문자열을 찾
        foreach(Match match in matches)
        {
            GroupCollection groups = match.Groups;
            print(groups[0].Index);
            print(groups[0].Value);
        }
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
}
