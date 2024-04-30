using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ThreeMG.Helper.SagaMapManagement;
using System.Linq;

public class SagaMapManager : SagaMap
{
    public static SagaMapManager Instance { get; private set; }
    public bool NonDestroyable = true;

    public LevelData levelData;
    private List<LevelType> levelTypes = new List<LevelType>();
    private LevelType[] levelArray = new LevelType[5];

    private void Awake()
    {
        SetAsSingleton();
    }

    private void OnEnable()
    {

    }

    private void SetAsSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            if (NonDestroyable)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GetLevelTypesFromLevelData();
        GenerateSagaMap(levelArray);
    }

    private void GetLevelTypesFromLevelData()
    {
        for (int i = 0; i < nodesInView; i++)
        {
            // levelTypes.Add(levelType.levelType);
            levelArray[i] = levelData.levels[i].levelType;
        }
    }

    public override void AnimateNodeProgression()
    {
        base.AnimateNodeProgression();
        Vector3 nextPos = nodeParent.transform.position;
        nextPos.y += 450f;

        //Tween To next pos
    }

    public void InitNodeClass()
    {

    }

    private void OnDisable()
    {

    }
}

