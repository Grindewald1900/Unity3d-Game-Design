using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class DrawTextUtils : MonoBehaviour
    {
        //Display some text and cursor for Goblin scene
        public static DrawTextUtils SharedInstance;
        private string _conversation;
        private string _mission;

        private GUIStyle _style1;

        private void Start()
        {
            SharedInstance = this;
            Cursor.visible = true;
            _style1 = new GUIStyle {fontSize = 10};
            _style1.normal.textColor = Color.black;
        }

        private void OnGUI()
        {
            // GUI.Label(new Rect(Screen.width/10f, Screen.height/10f, Screen.width/4f,Screen.height/3f),_mission);
            GUI.Label(new Rect(Screen.width / 5f, Screen.height/ 1.5f, Screen.width/2f, Screen.height/ 4f), _conversation, _style1 );
            
        }

        public void SetConversation(string content)
        {
            _conversation = content;
        }

        public void SetMission(string content)
        {
            _mission = content;
        }
        
       
    }
}
