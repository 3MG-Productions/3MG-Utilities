using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeMG.Helper.SagaMapManagement
{
    public class NodeItem : MonoBehaviour, INode
    {
        public NodeState nodeState { get; set; }
        public LevelType levelType { get; set; }
        public int nodeIndex { get; set; }
        public string levelName { get; set; }

        public GameObject nodePrefab;

        void Start()
        {
            UpdateLevelType();
            UpdateNodeState();
        }

        public void UpdateLevelType()
        {
            // Update the Leveltype here
            // This should only be called once.
        }

        public void UpdateNodeState()
        {
            //Change the lock status here
            nodeState = NodeState.UNLOCKED;
        }
    }
}

