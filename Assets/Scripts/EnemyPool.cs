using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool SharedInstance;
    public List<Enemy> enemyList;
    public Enemy enemyToPool;
    public int poolBulletAmount;
    // Start is called before the first frame update
    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemyList = new List<Enemy>();
        for (var i = 0; i < poolBulletAmount; i++)
        {
            var enemy = Instantiate(enemyToPool);
            enemy.SetIsActive(false);
            enemyList.Add(enemy);
        }
    }
  
    public Enemy GetNewEnemy()
    {
        foreach (var t in enemyList)
            if (!t.IsActiveInHierarchy())
                return t;

        return null;
    }
}
