namespace Player
{ 

    using UnityEngine;

    [AddComponentMenu("RPG Game/Player/Camera/First Person")]
    public class CameraControl : MonoBehaviour
    {
        [Header("Sensitivity Settings")]
        // Controls how fastr the camera rotates
        public float sensitivity = 8;
        // Toggles inverted verticle movement (so up is up and down is down)
        public bool invert = false;

        [Header("Rotating Clamping")]
        // Limits vertical rotation
        [SerializeField] Vector2 _verticalRotationClamp = new Vector2(-60, 60);

        [Header("Cammera Setup")]
        // Reference to the player object (horizontal)
        [SerializeField] Transform _player;
        // Reference to the camera object (vertical)
        [SerializeField] Transform _camera;
        // Stores the temporary vertical rotation
        [SerializeField] float _tempRotation;
        // Final vertical rotation value
        [SerializeField] float _verticalRotatoin;
        void Update()
        {
            // READ mouse x input ROATA player on y-axis using (Mouse X * sensitivity)
            _player.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            // READ mouse Y input ADD(Mouse Y * sesitivity) to temporary rotation value
            _tempRotation += Input.GetAxis("Mouse Y") * sensitivity;
            // CLAMP temporary rotation between min and max rotation limits
            _tempRotation = Mathf.Clamp(_tempRotation, _verticalRotationClamp.x, _verticalRotationClamp.y);

            // IF invert is enabled
            if (invert)
            {
                // SET vertical roation to temporary rotation
                _verticalRotatoin = _tempRotation;
            }
            // ELSE
            else
            {
                // SET vertical rotaion to negative temporary roation
                _verticalRotatoin = -_tempRotation;
            }
            // ENDIF

            // APPLY vertical rotation to the camera's local X - axis
            _camera.localEulerAngles = new Vector3(_verticalRotatoin, 0, 0);
        }
    }
}

