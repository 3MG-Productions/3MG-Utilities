using System;
using System.Collections;
using System.Collections.Generic;
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

public abstract class SagaMap : MonoBehaviour
{
    public List<NodeClass> nodeClasses = new List<NodeClass>();
    private int currentNodeIndex = 0;
    [field: SerializeField] protected int nodesInView = 4;
    [SerializeField] protected Transform nodeParent;
    private bool isProcedurallyGenerated = true;
    public List<NodeItem> nodes = new List<NodeItem>();
    public GameObject nodePrefab;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        nodes.Clear();
        currentNodeIndex = 0;
    }

    public virtual void AnimateNodeProgression()
    {
        // Animate the progression and move the nodes
    }

    public virtual void UpdateNode(NodeState nodeState)
    {
        nodes[currentNodeIndex].UpdateNodeState(nodeState);
        currentNodeIndex++;
    }

    public void GenerateSagaMap(LevelType[] levelTypes = null)
    {
        if (levelTypes == null)
        {
            Debug.LogError(">>>>> LevelTypes not found for instatiating nodes <<<<<");
            return;
        }

        for (int i = 0; i < nodesInView; i++)
        {
            InstantiateNewNodes(levelTypes[i]);
        }
    }

    public void InstantiateNewNodes(LevelType levelType)
    {
        GameObject newNode = Instantiate(nodePrefab, nodeParent);
        NodeData nodeData = newNode.GetComponent<NodeData>();

        nodeData.UpdateLevelType(levelType);

        nodeData.nodeIndex = currentNodeIndex;
        currentNodeIndex++;

        nodes.Add(nodeData);
    }

    public virtual void StartLevelGameplay()
    {

    }
}
