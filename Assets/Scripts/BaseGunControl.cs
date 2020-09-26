using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunControl : MonoBehaviour
{
    public AudioSource audioSource;
    private Transform _transform;
    private Camera _mainCamera;
    private Camera _aimCamera;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _transform = transform;
        _mainCamera = FindCameraByName("Main Camera");
        _aimCamera = FindCameraByName("Aim Camera");

        _aimCamera.enabled = false;

        // _transform.rotation = _transform.parent.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // newBullet.transform.rotation = transform.rotation;
            // newBullet.transform.rotation = transform.rotation;
            // newBullet.setInit(transform.forward,transform.position);
            // newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 10;

            var newBullet = BulletPool.SharedInstance.GetPoolObjects();
            if (ReferenceEquals(newBullet, null)) return;
            newBullet.SetInit(transform.right * (-1), _transform.position + _transform.right * (-1));
            newBullet.SetIsActive(true);
            audioSource.Play();
        }
        if (Input.GetMouseButtonDown(1))
        {
            _aimCamera.enabled = true;
            _mainCamera.enabled = false;

        }

        if (Input.GetMouseButtonUp(1))
        {
            _mainCamera.enabled = true;
            _aimCamera.enabled = false;
        }
    }

    private static Camera FindCameraByName(string name)
    {
        foreach (var c in Camera.allCameras)
        {
            if (c.name == name) return c;
        }
        return Camera.current;
    }
}
