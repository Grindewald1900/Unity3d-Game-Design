using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class DrawTextUtils : MonoBehaviour
    {
        public static DrawTextUtils SharedInstance;
        private String text;

        private void Start()
        {
            SharedInstance = this;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(Screen.width / 10f, Screen.height/ 1.2f, Screen.width/1.5f, Screen.height/ 4f), text );
        }

        public void SetContent(String content)
        {
            text = content;
        }
    }
}
