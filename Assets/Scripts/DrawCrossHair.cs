using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCrossHair : MonoBehaviour
{
    public Texture2D texture;
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width - texture.width) / 2f, (Screen.height - texture.height) / 2f, texture.width, texture.height), texture);
    }
}
