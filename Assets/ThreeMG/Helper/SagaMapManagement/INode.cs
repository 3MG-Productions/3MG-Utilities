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

        public void UpdateNodeState();
        public void UpdateLevelType();
    }

    public enum NodeState
    {
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