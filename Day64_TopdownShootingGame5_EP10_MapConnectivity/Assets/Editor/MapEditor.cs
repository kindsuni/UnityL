using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapEditor : Editor {

	public override void OnInspectorGUI ()
	{
        MapGenerator map = target as MapGenerator;

        if (DrawDefaultInspector()) //인스펙터 값이 바뀌면 제네레이터를 호출.
        {
            map.GenerateMap();
        }
        if(GUILayout.Button("Generate Map"))
        {
            map.GenerateMap();
        }
		//base.OnInspectorGUI ();

		//MapGenerator map = target as MapGenerator;

		//map.GenerateMap ();
	}

}