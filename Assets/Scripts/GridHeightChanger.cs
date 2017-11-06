using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridHeightChanger : MonoBehaviour
{
    public static float buildingHeight;
    public static int currentFloor;
    public static float floorSize = 2.3f;
    public Text floorLabel;

    void Start()
    {

    }
    void Update()
    {

    }
    public void GoFloorUp()
    {
        currentFloor++;
        transform.position = new Vector3(0, currentFloor * floorSize, 0);
        buildingHeight = transform.position.y;
        floorLabel.text = "Floor: " + currentFloor;
    }
    public void GoFloorDown()
    {
        currentFloor--;
        transform.position = new Vector3(0, currentFloor * floorSize, 0);
        buildingHeight = transform.position.y;
        floorLabel.text = "Floor: " + currentFloor;
    }
}
