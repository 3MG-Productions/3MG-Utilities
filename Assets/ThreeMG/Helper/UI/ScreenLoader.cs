using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

public enum ScreenType
{
    GameOver,
}

public class ScreenLoader : Singleton<ScreenLoader>
{
    [Serializable]
    public struct ScreenData
    {
        public ScreenType screenType;
        public AssetReferenceGameObject assetRef;
    }

    //    private List<ResourceData> resourceQueue = new List<ResourceData>();

    [SerializeField] List<ScreenData> screenDataList = new List<ScreenData>();
    [SerializeField] AssetManagment assetManagment;

    private ResourceData currentResourceData;

    bool isLoading = false;

    #region Public

    public void LoadScreen(ScreenType screenType, Action<object> callback)
    {
        ScreenData screenData = GetScreenData(screenType);
        currentResourceData = new ResourceData(null, screenData.assetRef, callback);

        if(!isLoading)
        {
            isLoading = true;
            assetManagment.AsyncLoadInstantiateObject(currentResourceData);
            currentResourceData.callback += HandleScreenInstantiated;
        }
    }

    public void UnloadLastScreen()
    {
        if(!isLoading)
        {
            assetManagment.UnloadAsset(currentResourceData.assetRef);
        }
    }

    #endregion

    #region Private
    private ScreenData GetScreenData(ScreenType screenType)
    {
        return screenDataList.Find(e => e.screenType.Equals(screenType));
    }

    #endregion

    #region Callback

    private void HandleScreenInstantiated(object obj)
    {
        currentResourceData.callback -= HandleScreenInstantiated;
        isLoading = false;
    }
    #endregion
}

