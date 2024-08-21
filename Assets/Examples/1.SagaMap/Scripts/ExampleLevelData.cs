using System;
using System.Collections;
using System.Collections.Generic;
using ThreeMG.Helper.SagaMapManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "3MG/SagaMap/LevelData", order = 0)]
public class ExampleLevelData : ScriptableObject
{
    public List<LevelInfo> levels = new List<LevelInfo>();
}

[Serializable]
public struct LevelInfo
{
    public LevelType levelType;
}

