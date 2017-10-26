using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetGeneration : MonoBehaviour
{

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Asset Generation/Items/Overworld Item")]
    public static void CreateAsset()
    {
        ItemAsset obj = ScriptableObject.CreateInstance<ItemAsset>();
        UnityEditor.AssetDatabase.CreateAsset(obj, "Assets/ScriptableObjects/Items/OverworldItems/newItem.asset");
    }
    [UnityEditor.MenuItem("Asset Generation/Items/LootTable")]
    public static void CreateLootTable()
    {
        LootTable obj = ScriptableObject.CreateInstance<LootTable>();
        UnityEditor.AssetDatabase.CreateAsset(obj, "Assets/ScriptableObjects/Items/OverworldItems/newLootTable.asset");
    }
#endif
}

public class ItemAsset : ScriptableObject
{
    public GameObject overworldPrefab;
}

public class LootTable : ScriptableObject
{
    public List<ItemAsset> lootTable;
    public List<float> dropChance;
}