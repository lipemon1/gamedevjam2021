using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;

        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] [Range(0f, 0.5f)] private float playerReduceSpeedMultiplier = 0.20f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -9.81f;

        bool _canMove;
        float _curSpeed;
        bool _reduceSpeed;

        Camera _camera;

        private void Awake()
        {
            _canMove = true;
            _curSpeed = playerSpeed;
            _reduceSpeed = false;
            _camera = Camera.main;
            controller = gameObject.GetComponent<CharacterController>();
        }

        private void Start()
        {
            PlayerDeath.PlayerDeathManager.Instance.OnPlayerDeath += () =>
            {
                _canMove = false;
            };
        }

        void Update()
        {
            if (!_canMove) return;

            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            /*
             * This little magic part was coded by Hazime
             * https://www.linkedin.com/in/hazimekondo/
             */

            //Start

            Vector3 foward = _camera.transform.forward;
            foward.y = 0f;

            Vector3 right = _camera.transform.right;
            right.y = 0f;

            Vector3 fowardMovement = Input.GetAxis("Vertical") * foward.normalized;
            Vector3 rightMovement = Input.GetAxis("Horizontal") * right.normalized;

            //End

            Vector3 move = fowardMovement + rightMovement;
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        public void ApplyReduceSpeed()
        {
            if (_reduceSpeed) return;

            _reduceSpeed = true;
            playerSpeed = _curSpeed * (1 - playerReduceSpeedMultiplier);
        }

        public void RemoveReduceSpeed()
        {
            _reduceSpeed = false;
            playerSpeed = _curSpeed;
        }
    }
}