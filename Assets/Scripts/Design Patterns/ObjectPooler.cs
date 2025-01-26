using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [SerializeField] private GameObject pooledObject;
    [SerializeField] private int pooledAmount;
    [SerializeField] private bool willGrow;

    List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
            Create();

    }

    void Create()
    {
        //o parent era transform, deixei null devido a problemas no tamanho dos objetos
        GameObject obj = (GameObject)Instantiate(pooledObject, parent: null);
        obj.SetActive(false);
        pooledObjects.Add(obj);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeSelf)
            {

                return pooledObjects[i];

            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject, parent: transform);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}