using System.Collections.Generic;
using System.Linq;
using EnemyScripts;
using UnityEngine;

namespace Utils
{
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
            return enemyList.FirstOrDefault(t => !t.IsActiveInHierarchy());
        }
    }
}
