using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
    float width = 2;
    float height = 2;

	// Use this for initialization
	void Start () {

        var mf = GetComponent<MeshFilter>();
        var mesh = mf.mesh;

        var vertices = new Vector3[4];

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(width, 0, 0);
        vertices[2] = new Vector3(0, height, 0);
        vertices[3] = new Vector3(width, height, 0);

        mesh.vertices = vertices;

        var tri = new int[12];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        tri[6] = 0;
        tri[7] = 1;
        tri[8] = 2;

        tri[9] = 3;
        tri[10] = 2;
        tri[11] = 1;

        mesh.triangles = tri;

        var nomals = new Vector3[4];

        nomals[0] = -Vector3.forward;
        nomals[1] = -Vector3.forward;
        nomals[2] = -Vector3.forward;
        nomals[3] = -Vector3.forward;

        mesh.normals = nomals;

        var uv = new Vector2[4];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0.5f, 0);
        uv[2] = new Vector2(0, 0.5f);
        uv[3] = new Vector2(0.5f, 0.5f);

        mesh.uv = uv;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
