using System;
using System.Collections;
using System.Collections.Generic;
using EnemyScripts;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    /// <summary>
    /// This class is the basic script for bullets
    /// </summary>
    /// <value> _direction: initial direction of the bullet </value>
    /// <value> _position: initial position of the bullet </value>
    /// <value> _timeAlive: bullet life time </value>
    /// <value> BulletSpeed: speed of bullet </value>
    private Vector3 _direction = new Vector3(0,0,0);
    private Vector3 _position = new Vector3(0,0,0);
    private float _timeAlive = 0f;
    private const int BulletSpeed = 30;

    private void Update()
    {
        // Inactivate the bullet after timeout
        if ((_timeAlive += Time.deltaTime) > 3)
        {
            gameObject.SetActive(false);
            _timeAlive = 0f;
        }
        // Bullet movement
        transform.position = _position + _direction * (_timeAlive * BulletSpeed);
        // Debug.Log(transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        var c = other.collider;
        var o = other.gameObject;
        if (!o.name.Contains("Enemy")) return;
        // Debug.Log("Collision object: " + o.name);
        var enemyBehavior = o.GetComponent<Enemy>();
        enemyBehavior.GetAttacked(2f);
    }


    /// <param name="direct"> Initial direction of the bullet </param>>
    /// <param name="pos"> Initial position of the bullet </param>>
    public void SetInit(Vector3 direct, Vector3 pos)
    {

        _direction = direct;
        _position = pos;
    }
    
    /// <summary>
    /// Set bullet status, invoked from other classes
    /// </summary>
    /// <param name="isActive">  </param>>
    public void SetIsActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    /// <summary>
    /// Check whether the GameObject is active in the Scene
    /// </summary>
    /// <returns></returns>
    public bool IsActiveInHierarchy()
    {
        return gameObject.activeInHierarchy;
    }
}
