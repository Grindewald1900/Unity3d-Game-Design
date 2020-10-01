using UnityEngine;

namespace PlayerScripts
{
    public class SightingZoom : MonoBehaviour
    {
        /// <summary> This class is implemented to deal with sighting zoom of guns </summary>
        /// <value> _aimCamera: camera of gun sight </value>
        /// <value> ZoomSpeed: speed of zoom in and zoom out </value>
        private Camera _aimCamera;
        private const float ZoomSpeed = 1f;
    
        // Start is called before the first frame update
        private void Start()
        {
            _aimCamera = GetComponent<Camera>();
        }

        // Update is called once per frame
        private void Update()
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel");
            // Scroll is positive when mouse wheel rotate forward
            if (scroll > 0f) 
                _aimCamera.fieldOfView -= ZoomSpeed;
            // Scroll is negative when mouse wheel rotate back
            else if(scroll < 0f)
                _aimCamera.fieldOfView += ZoomSpeed;
            // Restrict field of view in [10, 60]
            if (_aimCamera.fieldOfView > 60)
                _aimCamera.fieldOfView = 60;
            if (_aimCamera.fieldOfView < 10)
                _aimCamera.fieldOfView = 10;

            // Debug.Log("Zoom:" + _aimCamera.fieldOfView);
        }
    }
}
