using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
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

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}