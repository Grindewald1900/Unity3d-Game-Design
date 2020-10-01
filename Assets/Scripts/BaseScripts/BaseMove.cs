using UnityEngine;

namespace BaseScripts
{
    public class BaseMove : MonoBehaviour
    {
        public CharacterController controller;
        public Transform transGroudChecker;
        public float groundDistance = 0.1f;
        public LayerMask groundMask;
        public float gravity = -20f;
        public float jumpHeight = 3f;
        public float playerSpeed = 5f;
    
        private Vector3 _velocity;
        private Vector3 _movement;

        // Update is called once per frame
        private void Update()
        {
            _movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            _velocity.y += gravity * Time.deltaTime;
        
            if (Input.GetButton("Jump"))
            {
                _velocity.y = playerSpeed;
            }
            controller.Move(_velocity * Time.deltaTime + _movement * playerSpeed / 100);
        }
    }
}
