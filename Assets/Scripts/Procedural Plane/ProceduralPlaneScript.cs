using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UnityEngine.MeshFilter),typeof(UnityEngine.MeshRenderer))]
public class ProceduralPlaneScript : MonoBehaviour {

    public Vector2 planeSize = new Vector2(10.0f, 10.0f);
    Mesh m;

    // Use this for initialization
    void Start () {

        m = new Mesh();
        MeshFilter mf = GetComponent<MeshFilter>();
        mf.mesh = m;
        GenerateMesh();
	}

    void GenerateMesh()
    {
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();

        Vector3 vertexOne = new Vector3(planeSize.x/2, 0.0f, planeSize.y/2);
        Vector3 vertexTwo = new Vector3(planeSize.x/2, 0.0f, -planeSize.y/2);
        Vector3 vertexThree = new Vector3(-planeSize.x/2, 0.0f, -planeSize.y/2);
        Vector3 vertexFour = new Vector3(-planeSize.x/2, 0.0f, planeSize.y/2);

        verticies.Add(vertexOne);
        verticies.Add(vertexTwo);
        verticies.Add(vertexThree);
        verticies.Add(vertexFour);

        triangles.Add(3);
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(3);
        triangles.Add(1);
        triangles.Add(2);

        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);

        uvs.Add(new Vector2(1.0f, 1.0f));
        uvs.Add(new Vector2(1.0f, 0.0f));
        uvs.Add(new Vector2(0.0f, 0.0f));
        uvs.Add(new Vector2(0.0f, 1.0f));

        m.vertices = verticies.ToArray();
        m.triangles = triangles.ToArray();
        m.normals = normals.ToArray();
        m.uv = uvs.ToArray();
        m.name = "Procedural Plane Mesh";

        m.RecalculateBounds();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(planeSize.x, 0.0f, planeSize.y));
    }
}
