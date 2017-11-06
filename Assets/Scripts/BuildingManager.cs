using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildingManager : MonoBehaviour {
    public GameObject wallTool;
    public GameObject floorTool;
    public GameObject colourTool;
    public GameObject rearrangeTool;
    

    #region EnableModes
    public void EnableWallCreation()
    {
        DisableAllBuildingModes();
        wallTool.SetActive(true);
    }
    public void EnableFloorCreation()
    {
        DisableAllBuildingModes();
        floorTool.SetActive(true);
    }
    public void EnableColourMode()
    {
        DisableAllBuildingModes();
        colourTool.SetActive(true);
    }
    public void EnableRearrangeMode()
    {
        DisableAllBuildingModes();
        rearrangeTool.SetActive(true);
    }
    #endregion
    #region DisableModes
    void DisableWallCreation()
    {
        wallTool.SetActive(false);
    }
    void DisableFloorCreation()
    {
        floorTool.SetActive(false);
    }
    void DisableColourMode()
    {
        colourTool.SetActive(false);
    }
    void DisableRearrangeMode()
    {
        rearrangeTool.SetActive(false);
    }
    #endregion

    public void DisableAllBuildingModes()
    {
        DisableWallCreation();
        DisableFloorCreation();
        DisableColourMode();
        DisableRearrangeMode();
    }
}

[CustomEditor(typeof(BuildingManager))]
public class BuildingManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        BuildingManager myScript = (BuildingManager)target;
        if (GUILayout.Button("Wall Creation"))
        {
            myScript.EnableWallCreation();
        }
        if (GUILayout.Button("Floor Creation"))
        {
            myScript.EnableFloorCreation();
        }
        if (GUILayout.Button("Surface Painter"))
        {
            myScript.EnableColourMode();
        }
        if (GUILayout.Button("Rearrangement Tool"))
        {
            myScript.EnableRearrangeMode();
        }
    }
}