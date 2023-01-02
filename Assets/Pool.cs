using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    public static Pool instance;


    public GameObject shadowPrefab;

    public int shadowCount;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    void Awake()
    {
        instance = this;

        shadowPrefab = Resources.Load("Shadow") as GameObject;

        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            FillPool();
        }

        var outShadow = availableObjects.Dequeue();

        outShadow.SetActive(true);

        return outShadow;
    }



}
