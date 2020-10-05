using UnityEngine;

namespace Goblin.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController thirdPersonController;
        public Transform mainCamera;
        private float _speed;
        private float _turnSmoothTime;
        private float _currentVelocity;
        // Start is called before the first frame update
        private void Start()
        {
            _speed = 5f;
            _turnSmoothTime = 0.1f;
        }

        // Update is called once per frame
        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var direction = new Vector3(horizontal, 0, vertical).normalized;
            if (direction.magnitude < 0.1f) return;
            
            // Atan2 :Returns the angle in radians whose Tan is y/x.
            // Rad2Deg: Rad2Deg = 57.29578f, Radians-to-degrees conversion constant 
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            // Gradually changes an angle given in degrees towards a desired goal angle over time.
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _turnSmoothTime);
            var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            thirdPersonController.Move(moveDirection.normalized * (_speed * Time.deltaTime));
        }
    }
}
