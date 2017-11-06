using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMeshCreator : MonoBehaviour
{
    public void BuildMesh(Vector3 punktA, Vector3 punktB, Vector3 punktC, Vector3 punktD)
    {
        #region UVs
        float x = Vector3.Distance(punktA, punktB);
        float y = Vector3.Distance(punktC, punktB);
        Vector2[] newUV = new Vector2[] { new Vector2(0,0), new Vector2(x/ GridHeightChanger.floorSize, 0), new Vector2((x+y)/ GridHeightChanger.floorSize, 0), new Vector2(y/ GridHeightChanger.floorSize, 0), new Vector2(0, 1), new Vector2(x/ GridHeightChanger.floorSize, 1), new Vector2((x+y)/ GridHeightChanger.floorSize, 1), new Vector2(y/GridHeightChanger.floorSize, 1) };
        #endregion
        #region Vertices
        Vector3[] newVertices;
        newVertices = new Vector3[] { punktA, punktB, punktD, punktC, RaiseY(punktA, GridHeightChanger.floorSize), RaiseY(punktB, GridHeightChanger.floorSize), RaiseY(punktD, GridHeightChanger.floorSize), RaiseY(punktC, GridHeightChanger.floorSize) };
        #endregion
        #region Triangles
        int[] newTriangles = new int[] { 0, 1, 5, 0, 5, 4, 1, 2, 6, 1, 6, 5, 2, 3, 7, 2, 7, 6, 3, 0, 4, 3, 4, 7 };
        //newTriangles = new int[] { 0, 1, 5, 0, 5, 4, 1, 3, 7, 1, 7, 5, 3, 2, 6, 3, 6, 7, 2, 0, 4, 2, 4, 6 }; //Stara formuła, z uporządkowanym "newVertices"
        #endregion
        
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }
    Vector3 RaiseY(Vector3 point, float amount)
    {
        return new Vector3(point.x, point.y + amount, point.z);
    }
}

