using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotation : MonoBehaviour
{
    public Transform player;
    private const float MouseSensitive = 500f;
    private float _xRotation;

    // Update is called once per frame
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitive;
        var mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitive;
        player.Rotate(Vector3.up *  mouseX);
        _xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}
