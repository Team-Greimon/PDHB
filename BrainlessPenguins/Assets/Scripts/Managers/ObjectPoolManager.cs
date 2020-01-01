using System.Collections.Generic;
using UnityEngine;

// https://www.raywenderlich.com/847-object-pooling-in-unity 변형

[System.Serializable]
public class ObjectPoolItem
{
    public string poolName;
    public GameObject objectToPool;
    public int amountToPool;
    public bool constantSize;
}

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public const string DefaultRootObjectPoolName = "Pooled Objects";

    public string rootPoolName = DefaultRootObjectPoolName;
    public Dictionary<string, List<GameObject>> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void Awake()
    {
        if (string.IsNullOrEmpty(rootPoolName))
            rootPoolName = DefaultRootObjectPoolName;

        GetParentPoolObject(rootPoolName);

        pooledObjects = new Dictionary<string, List<GameObject>>();
        foreach (var item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                CreatePooledObject(item);
            }
        }
    }

    private void Start()
    {
        
    }

    private GameObject GetParentPoolObject(string objectPoolName)
    {
        // Use the root object pool name if no name was specified
        if (string.IsNullOrEmpty(objectPoolName))
            objectPoolName = rootPoolName;

        GameObject parentObject = GameObject.Find(objectPoolName);

        // Create the parent object if necessary
        if (parentObject == null)
        {
            parentObject = new GameObject();
            parentObject.name = objectPoolName;

            // Add sub pools to the root object pool if necessary
            if (objectPoolName != rootPoolName)
                parentObject.transform.parent = GameObject.Find(rootPoolName).transform;
        }

        return parentObject;
    }

    public GameObject GetPooledObject(string poolName)
    {
        var objectPool = pooledObjects[poolName];

        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
                return objectPool[i];
        }

        foreach (var item in itemsToPool)
        {
            if (item.poolName.Equals(poolName))
            {
                if (!item.constantSize)
                {
                    return CreatePooledObject(item);
                }
            }
        }

        return null;
    }

    private GameObject CreatePooledObject(ObjectPoolItem item)
    {
        if (!pooledObjects.ContainsKey(item.poolName))
        {
            pooledObjects[item.poolName] = new List<GameObject>();
        }

        GameObject obj = Instantiate(item.objectToPool);

        // Get the parent for this pooled object and assign the new object to it
        var parentPoolObject = GetParentPoolObject(item.poolName);
        obj.transform.parent = parentPoolObject.transform;

        obj.SetActive(false);
        pooledObjects[item.poolName].Add(obj);
        return obj;
    }
}