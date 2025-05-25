using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    // Pooling할 오브젝트
    [SerializeField] private GameObject objectToPool;
    // 미리 만들어 놓을 갯수
    [SerializeField] private int amountToPool = 10;
    // 미리 만들어진 객체들
    [SerializeField] private List<GameObject> pooledObjects = new List<GameObject>();

    private void Start()
    {
        AddPooling();
    }

    private void AddPooling()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            // 특정 GameObject를 하이어라키에 생성해주는 함수
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
                continue;
            pooledObjects[i].SetActive(true);
            return pooledObjects[i];
        }
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(true);
        pooledObjects.Add(obj);
        return obj;
    }
}
