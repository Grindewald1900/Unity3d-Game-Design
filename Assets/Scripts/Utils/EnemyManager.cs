using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    // [FormerlySerializedAs("RebirthPoint")] public GameObject rebirthPoint;

    private const float RebirthTime = 5f;
    private float _countDownTime;
    public Enemy enemyX;
    // Start is called before the first frame update
    private void Start()
    {
        _countDownTime = RebirthTime;
        CreateEnemy();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_countDownTime <= 0)
        {
            CreateEnemy();
            _countDownTime = RebirthTime;
        }
        _countDownTime -= Time.deltaTime;
    }

    private void CreateEnemy()
    {
        var enemy = EnemyPool.SharedInstance.GetNewEnemy();
        if (enemy.textHealth == null)
            enemy = Instantiate(enemyX);
        enemy.SetLocation(transform.position);
        enemy.SetIsActive(true);
        enemy.ResetEnemy();
    }
}
