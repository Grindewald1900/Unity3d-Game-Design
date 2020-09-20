using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotation : MonoBehaviour
{
    // public GameObject playerCamera;
    private float mouseSensitive = 200f;
    private float xRotation = 0f;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitive;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitive;
        
        player.Rotate(Vector3.up *  mouseX);
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // playerCamera.transform.Rotate(Input.GetAxis("Mouse Y") * _rotateSpeed, Input.GetAxis("Mouse X") * _rotateSpeed, 0, Space.World);

    }
}
