using System.Collections.Generic;
using System.Linq;
using ThreeMG.Helper.SagaMapManagement;
using UnityEngine;


[CreateAssetMenu(fileName = "SpriteMap", menuName = "SagaMap/SpriteMap", order = 0)]
public class SpriteDatabase : ScriptableObject
{
    public List<SpriteMap> SpriteMaps = new List<SpriteMap>();

    public Sprite GetSpriteByConfig(LevelType levelType, NodeState nodeState)
    {
        SpriteMap map = SpriteMaps.FirstOrDefault(x => x.LevelType == levelType);

        if(map != null)
        {
            return map.sprites[(int)nodeState];
        }

        return null;
    }
}
