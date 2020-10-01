using UnityEngine;

namespace PlayerScripts
{
    public class BaseGunControl : MonoBehaviour
    {
        public AudioSource shootAudio;
        private Transform _transform;
        private Camera _mainCamera;
        private Camera _aimCamera;

        private void Start()
        {
            shootAudio = GetComponent<AudioSource>();
            _transform = transform;
            _mainCamera = FindCameraByName("Main Camera");
            _aimCamera = FindCameraByName("Aim Camera");
            _aimCamera.enabled = false;

            // _transform.rotation = _transform.parent.rotation;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var newBullet = BulletPool.SharedInstance.GetPoolObjects();
                if (ReferenceEquals(newBullet, null)) return;
                newBullet.SetInit(transform.right * (-1), _transform.position + _transform.right * (-1));
                newBullet.SetIsActive(true);
                shootAudio.Play();
            }
            if (Input.GetMouseButtonDown(1))
            {
                _aimCamera.enabled = true;
                _mainCamera.enabled = false;

            }

            if (!Input.GetMouseButtonUp(1)) return;
            _mainCamera.enabled = true;
            _aimCamera.enabled = false;
        }

        private static Camera FindCameraByName(string name)
        {
            foreach (var c in Camera.allCameras)
            {
                if (c.name == name) return c;
            }
            return Camera.current;
        }
    }
}
