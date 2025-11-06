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
        // Stores the player's movement direction as a 3D vector (X, Y, Z)
        [SerializeField] Vector3 _movementDirection = Vector3.zero;
        // A reference to the Charcter controller component, which handles player movement
        [SerializeField] CharacterController _characterController;
        [Header("Speed That The Player Moves")]
        // Stores the current movement speed of the player
        [SerializeField] float _movementSpeed;
        // Different movement speed for walking, springing, crouching
        [SerializeField] float _walkSpeed = 5, _sprintSpeed = 10, _crouchSpeed = 2.5f;
        // Speed applied when the player jumps
        [SerializeField] float _jumpSpeed = 10;
        // Strength of the gravity aplied to the player to keep them grounded
        [SerializeField] float _gravity = 20;
        // Double jump check
        [SerializeField] bool _doubleJump = true;
        // Double jump time delay
        [SerializeField] float _doubleJumpDelay;
        // Stamina data set up
        
        void Start()
        {
            _characterController = this.GetComponent<CharacterController>();
        }

        void Update()
        {
            // adding a delay to the double jump, so they don't happen at the same time
            if (_doubleJumpDelay > 0)
            {
                _doubleJumpDelay = -Time.deltaTime;
            }
            // IF player on the ground
            if (_characterController.isGrounded)
            {
               // _doubleJump = false;
                // IF input shift AND has stamina
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // Speed = run speed
                    _movementSpeed = _sprintSpeed;
                }
                //  ELSE IF input ctrl
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    // Speed = crouch speed
                    _movementSpeed = _crouchSpeed;
                }
                // ELSE
                else
                {
                    // Speed = walk speed
                    _movementSpeed = _walkSpeed;
                }
                // ENDIF

                // SET movement direction
                _movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                // SET movement speed
                _movementDirection *= _movementSpeed;
                // SET direction from local to world
                _movementDirection = transform.TransformDirection(_movementDirection);

                // if input space
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Set movent to jump
                    _movementDirection.y = _jumpSpeed;
                    _doubleJump = true;
                    _doubleJumpDelay = 1;

                }
                //ENDIF
             }
             else if ((Input.GetKeyDown(KeyCode.Space)) && _doubleJump && _doubleJumpDelay <= 0)
            {
                // Set movent to jump
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