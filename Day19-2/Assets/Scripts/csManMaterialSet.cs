using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csManMaterialSet : MonoBehaviour
{

    public Material[] _M_Eyes;
    public Material[] _M_Hair1;
    public Material[] _M_Hair2;
    public Material[] _M_Top1;
    public Material[] _M_Top2;
    public Material[] _M_Pants1;
    public Material[] _M_Pants2;
    public Material[] _M_Shoes1;
    public Material[] _M_Shoes2;

    public GameObject _Eyes;
    public GameObject _Hair1;
    public GameObject _Hair2;
    public GameObject _Top1;
    public GameObject _Top2;
    public GameObject _Pants1;
    public GameObject _Pants2;
    public GameObject _Shoes1;
    public GameObject _Shoes2;



    // Use this for initialization
    void Start()
    {
        CharMaterialSet(_Eyes, _M_Eyes[1]);
        CharMaterialSet(_Eyes, _M_Hair1[1]);
        CharMaterialSet(_Eyes, _M_Hair2[1]);
        CharMaterialSet(_Eyes, _M_Top1[1]);
        CharMaterialSet(_Eyes, _M_Top2[1]);
        CharMaterialSet(_Eyes, _M_Pants1[1]);
        CharMaterialSet(_Eyes, _M_Pants2[1]);
        CharMaterialSet(_Eyes, _M_Shoes1[1]);
        CharMaterialSet(_Eyes, _M_Shoes2[1]);

    }
    void CharMaterialSet(GameObject obj, Material mat)

    {
        obj.GetComponent<Renderer>().material = mat;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
