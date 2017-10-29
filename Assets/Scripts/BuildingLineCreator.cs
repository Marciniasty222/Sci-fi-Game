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

    void Start ()
    {
        meshBuilder = GetComponent<WallMeshCreator>();
    }
    void Update () {
        if (Input.GetMouseButton(0))
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

            meshBuilder.BuildMesh(new Vector3(punktStart.transform.position.x + l * sinAlpha, 0, punktStart.transform.position.z - l * cosAlpha),
                new Vector3(punktStart.transform.position.x - l * sinAlpha, 0, punktStart.transform.position.z + l * cosAlpha),
                new Vector3(punktEnd.transform.position.x + l * sinAlpha, 0, punktEnd.transform.position.z - l * cosAlpha),
                new Vector3(punktEnd.transform.position.x - l * sinAlpha, 0, punktEnd.transform.position.z + l * cosAlpha));
        }
        else
        {
            punktA.transform.position =
            punktB.transform.position =
            punktC.transform.position =
            punktD.transform.position =
            punktStart.transform.position =
            punktEnd.transform.position = Vector3.down;
        }

		if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitRay;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hitRay, 128))
            {
                punktStart.transform.position = Vector3Int.RoundToInt(hitRay.point);
            }
        }
	}
    /*Vector2 FindPointA()
    {

    }
    Vector2 FindPointB()
    {

    }
    Vector2 FindPointC()
    {

    }
    Vector2 FindPointD()
    {

    }*/
}
