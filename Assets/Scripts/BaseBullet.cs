using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    private float _timeAlive = 0f;
    // Update is called once per frame
    void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive > 3)
        {
            gameObject.SetActive(false);
            _timeAlive = 0f;
        }
    }
}
