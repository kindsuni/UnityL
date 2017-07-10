using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDynamicChange : MonoBehaviour {

    public Material[] _M_Top1;
    public Material[] _M_Top2;
    public Material[] _M_Pants1;
    public Material[] _M_Pants2;

    public GameObject _Top1; 
    public GameObject _Top2; 
    public GameObject _Pants1;
    public GameObject _Pants2;

    int nTop1 = 0;
    int nTop2 = 0;
    int nPants1 = 0;
    int nPants2 = 0;

    public void ChangeTop1()
    {
        nTop1++;
        if(nTop1> _M_Top1.Length -1)
        {
            nTop1 = 0;
        }
        CharMaterialSet(_Top1, _M_Top1[nTop1]);

    }
    public void ChangeTop2()
    {
        nTop2++;
        if(nTop2 > _M_Top2.Length -1)
        {
            nTop2 = 0;
        }
        CharMaterialSet(_Top2, _M_Top2[nTop2]);
    }
    public void ChangePants1()
    {
        nPants1++;
        if (nPants1 > _M_Pants1.Length - 1)
        {
            nPants1 = 0;
        }
        CharMaterialSet(_Pants1, _M_Pants1[nPants1]);
    }
    public void ChangePants2()
    {
        nPants2++;
        if (nPants2 > _M_Pants2.Length - 1)
        {
            nPants2 = 0;
        }
        CharMaterialSet(_Pants2, _M_Pants2[nPants2]);
    } 

    void CharMaterialSet(GameObject obj, Material mat)
    {
        obj.GetComponent<Renderer>().material = mat; //오브젝트받아서 그 렌더러 컴포넌트의 머티리얼을 변경하는 메서드.
    }
    
}
