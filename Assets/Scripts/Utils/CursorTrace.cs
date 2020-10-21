using System;
using Goblin.PlayerScripts;
using UnityEngine;

namespace Utils
{
    public class CursorTrace : MonoBehaviour
    {
        private Vector3 _mouse;
        private Vector3 position;
        public PlayerController player;
        private bool _isShowMouseInfo;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void OnGUI()
        {
            if (_isShowMouseInfo)
            {
                GUI.Label(new Rect(_mouse.x + 30f, Screen.height - _mouse.y + 10f, Screen.width / 5f, Screen.height/5f), "Position: " + position.ToString() );
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                _mouse = Input.mousePosition;
                var castPoint = Camera.main.ScreenPointToRay(_mouse);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
                {
                    if (hit.collider.name.Contains("Terrain"))
                    {
                        _isShowMouseInfo = true;
                        position = hit.point;
                        player.SetDestination(hit.point);
                    }

                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Invoke("CloseMouseInfo",1f);
            }
        }

        private void CloseMouseInfo()
        {
            _isShowMouseInfo = false;
        }
        
    }
    
}
