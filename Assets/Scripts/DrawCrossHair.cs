using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCrossHair : MonoBehaviour
{
    public Texture2D texture;
    private Transform _transform;
    private RaycastHit _raycastHit;
    private float _crossHairScale;
    private void Start()
    {
        
        _transform = transform;
    }

    private void OnGUI()
    {
        _raycastHit = GetIntersectionDistance();
        _crossHairScale = _raycastHit.collider == null ? 0.1f : (float)MyUtils.GetZoomScaleByDistance(_raycastHit.distance);
        // Debug.Log("Scale: " + _crossHairScale);
        // crosshairImage.color = Color.Lerp(crosshairImage.color, m_CurrentCrosshair.crosshairColor, Time.deltaTime * crosshairUpdateshrpness);
        GUI.DrawTexture(new Rect((Screen.width - texture.width * _crossHairScale) / 2f, (Screen.height - texture.height * _crossHairScale) / 2f, texture.width * _crossHairScale, texture.height * _crossHairScale), texture);
    }

    private void Update()
    {
        GetIntersectionDistance();
    }

    private RaycastHit GetIntersectionDistance()
    {
        var position = _transform.position;
        var ray = new Ray(position, _transform.forward);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
        {
            // Debug.Log("Name: " + hit.collider.name);
            
        }
        return hit;
    }
}
