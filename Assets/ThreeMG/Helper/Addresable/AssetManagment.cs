using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

public struct ResourceData
{
    public Transform assetParent;
    public AssetReferenceGameObject assetRef;
    public Action<object> callback;

    public ResourceData(Transform inAssetParent, AssetReferenceGameObject inAssetRef, Action<object> inCallback)
    {
        assetParent = inAssetParent;
        callback = inCallback;
        assetRef = inAssetRef;
    }
}

public struct LoadedResourceData
{
    public GameObject assetGameObject;
    public AssetReferenceGameObject assetRef;

    public LoadedResourceData(GameObject loadedAsset, AssetReferenceGameObject inAssetRef)
    {
        assetGameObject = loadedAsset;
        assetRef = inAssetRef;
    }
}

public class AssetManagment : MonoBehaviour
{
    private List<ResourceData> resourceQueue = new List<ResourceData>();
    private List<LoadedResourceData> loadedResources = new List<LoadedResourceData>();

    #region Public

    public void AsyncLoadInstantiateObject(ResourceData resourceData)
    {
        if(resourceQueue.Count <= 0)
        {
            AsyncOperationHandle<GameObject> opHandle = Addressables.LoadAssetAsync<GameObject>(resourceData.assetRef);
            resourceQueue.Add(resourceData);
            StartCoroutine(WaitForResourceLoaded(resourceData, opHandle));
        }
    }

    public void UnloadAsset(AssetReferenceGameObject assetRef)
    {
        LoadedResourceData loadedAsset = loadedResources.Find(e => e.assetRef.Equals(assetRef));

        if(loadedAsset.assetGameObject != null)
        {
            Addressables.ReleaseInstance(loadedAsset.assetGameObject);
            loadedResources.Remove(loadedAsset);
        }
    }

    #endregion

    #region Private

    private IEnumerator WaitForResourceLoaded(ResourceData resourceData, AsyncOperationHandle<GameObject> opHandle)
    {
        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject obj = opHandle.Result;
            AsyncOperationHandle asyncOperation = Addressables.InstantiateAsync(obj, resourceData.assetParent, true);
            yield return asyncOperation;

            if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
            {
                resourceData.callback?.Invoke(asyncOperation.Result);
            }
            else
            {
                Debug.LogError("Resource Failed: " + resourceData.assetRef.SubObjectName);
            }
        }
        else
        {
            Debug.LogError("Resource Failed: " + resourceData.assetRef.SubObjectName);
        }

        resourceQueue.Remove(resourceData);

        if(resourceQueue.Count > 0)
        {
            AsyncLoadInstantiateObject(resourceQueue[0]);
        }
    }

    #endregion
}
