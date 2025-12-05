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
        // Stores the player's movement direction as a vector 3 (X, Y, Z)
        [SerializeField] Vector3 _movementDirection = Vector3.zero;
        // A reference to the Charcter controller component, which handles player movement while also making it visable in the inspector
        [SerializeField] CharacterController _characterController;
        [Header("Speed That The Player Moves")]
        // Stores the current movement speed of the player while also making it visable in the inspector
        [SerializeField] float _movementSpeed;
        // Different movement speed for walking, springing, crouching thats also been made visable inside the inspector
        [SerializeField] float _walkSpeed = 5, _sprintSpeed = 10, _crouchSpeed = 2.5f;
        // Speed applied when the player jumps is also visable in the inspector
        [SerializeField] float _jumpSpeed = 10;
        // Strength of the gravity applied to the player to pull them back down when they jump, it is also visable in the inspector
        [SerializeField] float _gravity = 20;
        // Double jump check to make sure you only double jump while mid air
        [SerializeField] bool _doubleJump = true;
        // created Double jump time delay to prevent rapid fast double jump spamming
        [SerializeField] float _doubleJumpDelay;
        // Stamina data set up 

        void Start()
        {
            _characterController = this.GetComponent<CharacterController>();
        }

        void Update()
        {
            // adding a delay script to the double jump delay, so they don't happen at the same time
            if (_doubleJumpDelay > 0)
            {
                _doubleJumpDelay = -Time.deltaTime;
            }
            // IF player is on the ground
            if (_characterController.isGrounded)
            {
                // _doubleJump = false;
                // if input shift and stamina bar is not empty
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // Speed = sprint speed
                    _movementSpeed = _sprintSpeed;
                }
                //  ELSE IF input ctrl
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    // Speed = crouch speed
                    _movementSpeed = _crouchSpeed;
                }
                // ELSE in case you do not press those buttons or stamina bar is empty while moving
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

                // if pressed space
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Set movement to jump
                    _movementDirection.y = _jumpSpeed;
                    _doubleJump = true;
                    _doubleJumpDelay = 1;

                }
                //ENDIF
            }
            else if ((Input.GetKeyDown(KeyCode.Space)) && _doubleJump && _doubleJumpDelay <= 0)
            {
                // Set movement to jump
                _movementDirection.y = _jumpSpeed;
                _doubleJump = false;
            }
            //ENDIF

            // Set gravity
            _movementDirection.y -= _gravity * Time.deltaTime;
            _characterController.Move(_movementDirection * Time.deltaTime);
        }
    }

}