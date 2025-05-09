using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
            
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        GameManager.INSTANCE.FimdaWave.AddListener(ResetPool);
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void ResetPool()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.FimdaWave?.RemoveListener(ResetPool);
    }
}
