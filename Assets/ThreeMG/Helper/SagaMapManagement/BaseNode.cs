using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeMG.Helper.SagaMapManagement
{
    public abstract class NodeItem : MonoBehaviour, INode
    {
        public NodeState nodeState { get; set; }
        public LevelType levelType { get; set; }
        public int nodeIndex { get; set; }
        public string levelName { get; set; }

        void Start()
        {
            Init();
        }

        public void Init()
        {
            UpdateNodeState(this.nodeState);
        }

        public virtual void UpdateLevelType(LevelType levelType)
        {
            // Update the Leveltype here
            // This should only be called once.

            this.levelType = levelType;
        }



        public virtual void UpdateNodeState(NodeState nodeState)
        {
            //Change the lock status here
            this.nodeState = nodeState;
        }

        public void NodeClicked()
        {
            
        }
    }
}

