using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMeshCreator : MonoBehaviour
{
    public float floorHeight;
    public void BuildMesh(Vector3 punktA, Vector3 punktB, Vector3 punktC, Vector3 punktD)
    {
        Vector3[] newVertices;
        Vector2[] newUV = new Vector2[0]; //TODO: Dla ściany wyznaczyć wielkość powierzchni
        int[] newTriangles;

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        newVertices = new Vector3[] { punktA, punktB, punktD, punktC, RaiseY(punktA, floorHeight), RaiseY(punktB, floorHeight), RaiseY(punktD, floorHeight), RaiseY(punktC, floorHeight) };
        newTriangles = new int[] { 0, 1, 5, 0, 5, 4, 1, 2, 6, 1, 6, 5, 2, 3, 7, 2, 7, 6, 3, 0, 4, 3, 4, 7 };
      //newTriangles = new int[] { 0, 1, 5, 0, 5, 4, 1, 3, 7, 1, 7, 5, 3, 2, 6, 3, 6, 7, 2, 0, 4, 2, 4, 6 };


        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }
    Vector3 RaiseY(Vector3 point, float amount)
    {
        return new Vector3(point.x, point.y + amount, point.z);
    }
}

