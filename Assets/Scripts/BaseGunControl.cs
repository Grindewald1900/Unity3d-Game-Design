using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunControl : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        // newBullet.transform.rotation = transform.rotation;
        // newBullet.transform.rotation = transform.rotation;
        // newBullet.setInit(transform.forward,transform.position);
        // newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 10;

        var newBullet = BulletPool.SharedInstance.GetPoolObjects();
        if(ReferenceEquals(newBullet, null)) return;
        newBullet.setInit(transform.right * (-1), transform.position + transform.right * (-1));
        newBullet.setIsActive(true);
        audioSource.Play();
    }
}
