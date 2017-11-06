using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLineCreator : MonoBehaviour {
    public GameObject punktA;
    public GameObject punktB;
    public GameObject punktC;
    public GameObject punktD;
    public GameObject punktStart; //A
    public GameObject punktEnd; //B
    [Tooltip("Szerokość ściany")]
    public float l = 0.1f; //Grubość ściany
    WallMeshCreator meshBuilder;
    public GameObject houseModel;

    void Start ()
    {
        meshBuilder = GetComponent<WallMeshCreator>();
    }
    void Update () {
        if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
        {
            RaycastHit hitRay;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hitRay, 128))
            {
                punktEnd.transform.position = Vector3Int.RoundToInt(hitRay.point);
            }
            float sinAlpha = 0;
            float cosAlpha = 0;

            if (punktStart.transform.position != punktEnd.transform.position)
            {
                sinAlpha = (punktEnd.transform.position.z - punktStart.transform.position.z) / (Mathf.Sqrt(Mathf.Pow((punktEnd.transform.position.x - punktStart.transform.position.x), 2) + Mathf.Pow((punktEnd.transform.position.z - punktStart.transform.position.z), 2)));
                cosAlpha = (punktEnd.transform.position.x - punktStart.transform.position.x) / (Mathf.Sqrt(Mathf.Pow((punktEnd.transform.position.x - punktStart.transform.position.x), 2) + Mathf.Pow((punktEnd.transform.position.z - punktStart.transform.position.z), 2)));
            }
            punktA.transform.position = new Vector3(punktStart.transform.position.x + l * sinAlpha, 0, punktStart.transform.position.z - l * cosAlpha);
            punktB.transform.position = new Vector3(punktStart.transform.position.x - l * sinAlpha, 0, punktStart.transform.position.z + l * cosAlpha);
            punktC.transform.position = new Vector3(punktEnd.transform.position.x + l * sinAlpha, 0, punktEnd.transform.position.z - l * cosAlpha);
            punktD.transform.position = new Vector3(punktEnd.transform.position.x - l * sinAlpha, 0, punktEnd.transform.position.z + l * cosAlpha);

            meshBuilder.BuildMesh(new Vector3(punktStart.transform.position.x + l * sinAlpha, hitRay.point.y, punktStart.transform.position.z - l * cosAlpha),
                new Vector3(punktStart.transform.position.x - l * sinAlpha, hitRay.point.y, punktStart.transform.position.z + l * cosAlpha),
                new Vector3(punktEnd.transform.position.x + l * sinAlpha, hitRay.point.y, punktEnd.transform.position.z - l * cosAlpha),
                new Vector3(punktEnd.transform.position.x - l * sinAlpha, hitRay.point.y, punktEnd.transform.position.z + l * cosAlpha));
        }

		if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
        {
            RaycastHit hitRay;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hitRay, 128))
            {
                punktStart.transform.position = Vector3Int.RoundToInt(hitRay.point);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (punktStart.transform.position - punktEnd.transform.position != Vector3.zero)
            {
                GameObject newWall = new GameObject("NewWall", typeof(MeshFilter), typeof(MeshRenderer));
                newWall.transform.SetParent(houseModel.transform);
                GetComponent<MeshFilter>().mesh.RecalculateNormals();
                GetComponent<MeshFilter>().mesh.RecalculateBounds();
                newWall.GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
                newWall.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
            }
            punktA.transform.position =
            punktB.transform.position =
            punktC.transform.position =
            punktD.transform.position =
            punktStart.transform.position =
            punktEnd.transform.position = Vector3.down;
        }
	}
}
