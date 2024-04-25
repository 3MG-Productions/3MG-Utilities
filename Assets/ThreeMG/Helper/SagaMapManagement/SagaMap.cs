using System;
using System.Collections;
using System.Collections.Generic;
using ThreeMG.Helper.SagaMapManagement;
using UnityEngine;

public abstract class SagaMap : MonoBehaviour
{
    private int currentNodeIndex = 0;
    protected int nodesInView = 3;
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

    public void AnimateNodeProgression()
    {

    }

    public virtual void UpdateNode()
    {
        nodes[currentNodeIndex].UpdateNodeState();
        currentNodeIndex++;

    }

    public void GenerateSagaMap()
    {
        for (int i = 0; i < nodesInView; i++)
        {
            InstantiateNewNodes();
        }
    }

    public virtual void StartLevelGameplay()
    {

    }

    public void InstantiateNewNodes()
    {
        GameObject newNode = Instantiate(nodePrefab);

    }
}
