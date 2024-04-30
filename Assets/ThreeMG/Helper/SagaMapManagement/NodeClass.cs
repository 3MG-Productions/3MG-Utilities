using System;
using ThreeMG.Helper.SagaMapManagement;
using UnityEngine;

[Serializable]
public class NodeClass
{
    [field: SerializeField] public LevelType levelType { get; set; }
    [field: SerializeField] public Sprite levelSprite { get; set; }

    public NodeClass(LevelType levelType, Sprite levelSprite)
    {
        this.levelType = levelType;
        this.levelSprite = levelSprite;
    }
}
