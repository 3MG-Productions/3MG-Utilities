using System.Collections;
using System.Collections.Generic;
using ThreeMG.Helper.SagaMapManagement;
using UnityEngine;

public abstract class BaseSagaMap : MonoBehaviour
{
    private bool isProcedurallyGenerated = true;
    [SerializeField] protected Transform nodeParent;

    public int currentNodeIndex = 0;
    public List<NodeItem> nodes = new List<NodeItem>();
    public GameObject nodePrefab;
    public int startIndex = 0;

    [field: SerializeField] protected int nodesInView = 4;
    [field: SerializeField] public SpriteDatabase SpriteDatabase { get; private set; }


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
        ExampleNode nodeData = newNode.GetComponent<ExampleNode>();

        nodeData.UpdateLevelType(levelType);

        nodeData.nodeIndex = startIndex;
        startIndex++;

        nodes.Add(nodeData);
    }

    public void UpdateCurrentNode()
    {
        nodes[currentNodeIndex].UpdateNodeState(NodeState.CURRENT);
    }

    public virtual void StartLevelGameplay()
    {

    }
}
