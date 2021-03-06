﻿using UnityEngine;

namespace Goblin.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController thirdPersonController;
        public Transform mainCamera;
        public Animator playerAnimator;
        private float _speed;
        private float _turnSmoothTime;
        private float _currentVelocity;
        private Vector3 _destination;
        private bool _isRoute;
        private static readonly int Walk = Animator.StringToHash("walk");
        
        // Start is called before the first frame update
        private void Start()
        {
            _speed = 8f;
            _turnSmoothTime = 0.1f;
        }

        // Update is called once per frame
        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var direction = new Vector3(horizontal, 0, vertical).normalized;
            if (direction.magnitude < 0.1f && !_isRoute) {
                playerAnimator.SetBool(Walk,false);
                return;
            }
            if (direction.magnitude > 0.1f)
            {
                _isRoute = false;
            }

            // Atan2 :Returns the angle in radians whose Tan is y/x.
            // Rad2Deg: Rad2Deg = 57.29578f, Radians-to-degrees conversion constant 
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            // Gradually changes an angle given in degrees towards a desired goal angle over time.
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _turnSmoothTime);
            var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // if (!playerAnimator.GetBool(Walk))
            // {
            //     playerAnimator.SetBool(Walk,true);
            //     Debug.Log("walk");
            // }
            
            playerAnimator.SetBool(Walk,true);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            thirdPersonController.Move(moveDirection.normalized * (_speed * Time.deltaTime));
            if (_isRoute){}
            {
                MoveToCursor();
            }
            
            
        }

        private void MoveToCursor()
        {
            var playerPosition = transform.position;
            var distance = Vector3.Distance(playerPosition, _destination);
            var normalizedDirection = new Vector3((playerPosition.x - _destination.x) * Time.deltaTime * _speed/ distance,0f,(playerPosition.z - _destination.z)  * Time.deltaTime * _speed/ distance);
            // canvas.transform.Rotate(Quaternion.FromToRotation(Vector3.forward, normalizedDirection).eulerAngles);
            transform.Translate(normalizedDirection);
            // ResetCanvasRotation();
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
            _isRoute = true;
        }
    }
}
