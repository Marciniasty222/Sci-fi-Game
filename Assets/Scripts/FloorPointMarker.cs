using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorPointMarker : MonoBehaviour
{

    public GameObject floorPointPrefab;
    public GameObject houseModel;
    public Material material;
    public GameObject objectHover;

    public Vector2[] array;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
        {
            RaycastHit hitRay;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hitRay, 128))
            {
                GameObject point = Instantiate(floorPointPrefab, new Vector3( Vector3Int.RoundToInt(hitRay.point).x, hitRay.point.y, Vector3Int.RoundToInt(hitRay.point).z), Quaternion.identity, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (Transform childPoint in transform)
            {
                Destroy(childPoint.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            #region Triangulate

            // Create Vector2 vertices
            Vector2[] vertices2D = new Vector2[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                vertices2D[i] = new Vector2( transform.GetChild(i).position.x, transform.GetChild(i).position.z);

            }

            // Use the triangulator to get indices for creating triangles
            Triangulator tr = new Triangulator(vertices2D);
            int[] indices = tr.Triangulate();

            // Create the Vector3 vertices
            Vector3[] vertices = new Vector3[vertices2D.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vector3(vertices2D[i].x, GridHeightChanger.buildingHeight, vertices2D[i].y);
            }
            int[] reverseIndices = new int[indices.Length];
            reverseIndices = indices;
            reverseIndices = ReverseArray(reverseIndices);

            int[] z = new int[reverseIndices.Length + indices.Length];
            reverseIndices.CopyTo(z, 0);
            indices.CopyTo(z, reverseIndices.Length);

            // Create the mesh
            Mesh msh = new Mesh();
            
            msh.vertices = vertices;
            msh.triangles = z;
            Vector2[] UVs = new Vector2[msh.vertices.Length];
            
            for (int i = 0; i < msh.vertices.Length; i++)
            {
                UVs[i] = new Vector2(vertices[i].x, vertices[i].z);
            }
            msh.uv = UVs;

            array = UVs;




            //msh.RecalculateNormals(); //Czarny mesh, słabo :(
            msh.RecalculateBounds();

            if (msh.vertices.Length >= 3)
            {
                GameObject newWall = new GameObject("NewFloor", typeof(MeshFilter), typeof(MeshRenderer));
                newWall.transform.SetParent(houseModel.transform);
                newWall.GetComponent<MeshFilter>().mesh = msh;
                newWall.GetComponent<MeshRenderer>().material = material;
            }
            #endregion

            foreach (Transform childPoint in transform)
            {
                Destroy(childPoint.gameObject);
            }
        }
    }
    int[] ReverseArray(int[] array)
    {
        int[] arrayReversed = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            arrayReversed[array.Length - i - 1] = array[i];
        }
        return arrayReversed;
    }
}
