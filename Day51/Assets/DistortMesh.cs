using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortMesh : MonoBehaviour {
    public float phase = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;
        int p = 0;
        while(p < vertices.Length && phase >0)
        {
            vertices[p] += new Vector3(0, Random.Range(-0.3f, 0.3f), 0);
            p++;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();

        if(phase > 0)
        {
            phase--;
        }
	}
}
