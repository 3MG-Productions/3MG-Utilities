using System;
using System.Collections;
using System.Collections.Generic;
using ThreeMG.Helper.SagaMapManagement;
using UnityEngine;

public abstract class SagaMap : MonoBehaviour
{
    private int currentNodeIndex = 0;
    [SerializeField] protected int nodesInView = 3;
    [SerializeField] private bool isProcedurallyGenerated = true;
    public List<NodeItem> nodes = new List<NodeItem>();

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

    }

    public virtual void StartLevelGameplay()
    {

    }
}
