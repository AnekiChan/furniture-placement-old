using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnitureScriptbleObject", menuName = "ScriptbleObjects/furniture")]
public class FurnitureScriptbleObject : ScriptableObject
{
    public GameObject prefab;

    public int rank;
    public int cost;

    [Header("Item type matching (from 1 to 5)")]
    public int cute;
    public int modern;
    public int classic;
}
