using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using ThreeMG.Helper.SagaMapManagement;
using TMPro;
using UnityEngine;

public class ExampleNode : NodeItem
{
    public TextMeshProUGUI levelID;
    public UnityEngine.UI.Image nodeIcon;
    public UnityEngine.UI.Button nodeButton;

    // Start is called before the first frame update
    void Start()
    {
        nodeButton.onClick.AddListener(() => OnButtonClick());

        levelID.text = nodeIndex.ToString();
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        nodeIcon.sprite = GetSprite(levelType);
    }

    private Sprite GetSprite(LevelType levelType)
    {
        foreach (SpriteMap spriteMap in ExampleSagaMapManager.Instance.SpriteDatabase.SpriteMaps)
        {
            if (spriteMap.LevelType == levelType)
            {
                return spriteMap.sprites[2];
            }
        }

        return null;
    }

    private void OnButtonClick()
    {
        ExampleSagaMapManager.Instance.UpdateNode(NodeState.COMPLETED);
        ExampleSagaMapManager.Instance.AnimateNodeProgression();
    }

    public override void UpdateLevelType(LevelType levelType)
    {
        base.UpdateLevelType(levelType);
    }

    public override void UpdateNodeState(NodeState nodeState)
    {
        base.UpdateNodeState(nodeState);

        nodeIcon.sprite = ExampleSagaMapManager.Instance.SpriteDatabase.GetSpriteByConfig(levelType, nodeState);
    }
}