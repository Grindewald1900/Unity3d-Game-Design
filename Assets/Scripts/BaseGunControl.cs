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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = ObjectPool.SharedInstance.GetPoolObjects();
            newBullet.transform.position = transform.position + transform.forward;
            // newBullet.GetComponent<Rigidbody>().velocity = new Vector3(-1,0,0);
            newBullet.SetActive(true);
            audioSource.Play();

        }
    }
}
