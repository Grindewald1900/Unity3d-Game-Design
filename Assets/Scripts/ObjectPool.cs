﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> poolObjects;
    public GameObject objectToPool;
    public int poolBulletAmount;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        poolObjects = new List<GameObject>();
        for (int i = 0; i < poolBulletAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    public GameObject GetPoolObjects()
    {
        for(int i = 0; i < poolBulletAmount; i++)
            if (!poolObjects[i].activeInHierarchy)
                return poolObjects[i];
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
