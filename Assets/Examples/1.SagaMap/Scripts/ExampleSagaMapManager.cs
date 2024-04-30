using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ThreeMG.Helper.SagaMapManagement;
using System.Linq;

public class ExampleSagaMapManager : BaseSagaMap
{
    // [field: SerializeField] public SpriteDatabase SpriteDatabase { get; private set; }
    private List<LevelType> levelTypes = new List<LevelType>();
    private LevelType[] levelArray = new LevelType[5];

    public static ExampleSagaMapManager Instance { get; private set; }
    public bool NonDestroyable = true;
    public LevelData levelData;


    private bool canTween = false;

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

        UpdateCurrentNode();
    }

    private void GetLevelTypesFromLevelData()
    {
        for (int i = 0; i < nodesInView; i++)
        {
            levelArray[i] = levelData.levels[i].levelType;
        }
    }

    public override void AnimateNodeProgression()
    {
        base.AnimateNodeProgression();
        StartCoroutine(AnimateWithDelay(1.5f));
    }

    Vector3 nextPos;
    Vector3 pos;
    private IEnumerator AnimateWithDelay(float deltaTime = 0f)
    {
        yield return new WaitForSeconds(deltaTime);

        nextPos = nodeParent.transform.position;
        pos = nodeParent.transform.position;
        nextPos.y -= 30f;

        //Tween To next pos
        canTween = true;
    }

    float timeElapsed;
    float lerpDuration = 1;
    private void Update()
    {
        if (canTween)
        {
            if (timeElapsed < lerpDuration)
            {
                pos = Vector3.Lerp(pos, nextPos, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;

                nodeParent.transform.position = pos;
            }
            else
            {
                canTween = false;
                timeElapsed = 0f;
                UpdateCurrentNode();

                // Instatiate nextNode
            }
        }
    }
}

