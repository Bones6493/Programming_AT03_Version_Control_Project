using UnityEngine;

namespace Player
{
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("RPG Game/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Moving Player Direction")]
        // Stores the player's 3D movement by using a Vector 3 (X, Y, Z)
        [SerializeField] Vector3 _movementDirection = Vector3.zero;
        // A reference to the Charcter controller component, which handles player movement
        [SerializeField] CharacterController _characterController;
        [Header("Speed That The Player Moves")]
        // Stores the current movement speed of the player
        [SerializeField] float _movementSpeed;
        // Different movement speed for walking, springing, crouching depending on what the movement speed is equal to at the time
        [SerializeField] float _walkSpeed = 5, _sprintSpeed = 10, _crouchSpeed = 2.5f;
        // Speed applied when the player jumps
        [SerializeField] float _jumpSpeed = 10;
        // Strength of the gravity aplied to the player to pull them back to the ground
        [SerializeField] float _gravity = 20;
        // Checks if the player can double jump
        [SerializeField] bool _doubleJump = true;
        // Double jump time delay to prevent triple jumps or super high jumps
        [SerializeField] float _doubleJumpDelay;
        // Stamina data set up 
        
        void Start()
        {
            _characterController = this.GetComponent<CharacterController>();
        }

        void Update()
        {
            // adding a delay to the double jump, to prevent jumping twice at the same time
            if (_doubleJumpDelay > 0)
            {
                _doubleJumpDelay = -Time.deltaTime;
            }
            // IF player on the ground
            if (_characterController.isGrounded)
            {
               // _doubleJump = false; player cannot double jump
                // IF input shift AND has stamina 
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // movement speed = run speed, this changes the players movement speed to its sprint speed making the player move faster
                    _movementSpeed = _sprintSpeed;
                }
                //  ELSE IF input ctrl
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    // movement Speed = crouch speed, the player's movement speed is now set to crouch speed making the player move slower
                    _movementSpeed = _crouchSpeed;
                }
                // ELSE
                else
                {
                    // Speed = walk speed if no other keys were pressed or player has no stamina then the speed stays the default walk speed
                    _movementSpeed = _walkSpeed;
                }
                // ENDIF

                // SET movement direction and stores X, Y and Z axis
                _movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                // SET movement speed 
                _movementDirection *= _movementSpeed;
                // SET direction from local to world 
                _movementDirection = transform.TransformDirection(_movementDirection);

                // if input spacebar 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Set y axis movement to jump speed and set double jump to true while mid air 
                    _movementDirection.y = _jumpSpeed;
                    _doubleJump = true;
                    _doubleJumpDelay = 1;

                }
                //ENDIF
             }
             else if ((Input.GetKeyDown(KeyCode.Space)) && _doubleJump && _doubleJumpDelay <= 0)
            {
                // Set y axis movement to jump speed
                _movementDirection.y = _jumpSpeed;
                _doubleJump = false;
            }
            //ENDIF

            // SET gravity 
            _movementDirection.y -= _gravity * Time.deltaTime;
            _characterController.Move(_movementDirection *  Time.deltaTime);
        }
    }

}