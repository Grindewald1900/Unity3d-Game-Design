using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    private Vector3 _direction = new Vector3(0,0,0);
    private Vector3 _position = new Vector3(0,0,0);
    private float _timeAlive = 0f;
    private int _bulletSpeed = 10;
    
    // Update is called once per frame
    void Update()
    {
        _timeAlive += Time.deltaTime;
        // Debug.Log("Time:" + transform.position);
        if (_timeAlive > 3)
        {
            gameObject.SetActive(false);
            _timeAlive = 0f;
        }
        transform.position = _position + _direction * (_timeAlive * _bulletSpeed);

        // Debug.Log(transform.position);

    }

    public void setInit(Vector3 direct, Vector3 pos)
    {
        _direction = direct;
        _position = pos;
    }

    public void setIsActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public bool isActiveInHierarchy()
    {
        return gameObject.activeInHierarchy;
    }
}
