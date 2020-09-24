using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<BaseBullet> BaseBulletList;
    public BaseBullet objectToPool;
    public int poolBulletAmount;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        BaseBulletList = new List<BaseBullet>();
        for (var i = 0; i < poolBulletAmount; i++)
        {
            var bullet = Instantiate(objectToPool);
            bullet.setIsActive(false);
            BaseBulletList.Add(bullet);
        }
    }

    public BaseBullet GetPoolObjects()
    {
        for(int i = 0; i < BaseBulletList.Count; i++)
            if (!BaseBulletList[i].isActiveInHierarchy())
                return BaseBulletList[i];
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}