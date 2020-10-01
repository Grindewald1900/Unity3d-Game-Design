using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    /// <summary>
    /// Initialize some bullets in the begining
    /// </summary>
    public static BulletPool SharedInstance;
    public List<BaseBullet> baseBulletList;
    public BaseBullet objectToPool;
    public int poolBulletAmount;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        baseBulletList = new List<BaseBullet>();
        for (var i = 0; i < poolBulletAmount; i++)
        {
            var bullet = Instantiate(objectToPool);
            bullet.SetIsActive(false);
            baseBulletList.Add(bullet);
        }
    }

    public BaseBullet GetPoolObjects()
    {
        foreach (var t in baseBulletList)
            if (!t.IsActiveInHierarchy())
                return t;

        return null;
    }
}