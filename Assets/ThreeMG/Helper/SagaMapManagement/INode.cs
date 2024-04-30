using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeMG.Helper.SagaMapManagement
{    
    public interface INode
    {
        int nodeIndex { get; set; }
        string levelName { get; set; }
        NodeState nodeState { get; set; }
        LevelType levelType { get; set; }

        public void UpdateNodeState(NodeState nodeState);
        public void UpdateLevelType(LevelType levelType);
    }

    public enum NodeState
    {
        CURRENT,
        LOCKED,
        UNLOCKED
    }

    public enum LevelType
    {
        EASY,
        MEDIUM,
        HARD,
        SPECIAL
    }
}