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

        [Header("Camera Transition Settings")]
        public float transitionSpeed = 5;

        [Header("Zoom Settings")]
        [SerializeField] float minZoom = 0f;
        [SerializeField] float maxZoom = 5f;
        [SerializeField] float zoomSpeed = 2f;
        private float currentZoom = 0f;

        [Header("Cammera Setup")]
        // Reference to the player object (horizontal)
        [SerializeField] Transform _player;
        // Reference to the camera object (vertical)
        [SerializeField] Transform _camera;
        // Stores the temporary vertical rotation
        [SerializeField] float _tempRotation;
        // Final vertical rotation value
        [SerializeField] float _verticalRotatoin;
        public Transform firstPersonSnap;
        public Transform thirdPersonSnap;
        public Transform thirdPersonParent;
        void Update()
        {
            HnadleZoom();
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
            // _camera.localEulerAngles = new Vector3(_verticalRotatoin, 0, 0);
            firstPersonSnap.localEulerAngles = new Vector3(_verticalRotatoin, 0, 0);
            thirdPersonParent.localEulerAngles = new Vector3(_verticalRotatoin, 0, 0);
        }

        private void HnadleZoom()
        {
            // save the current amuont scroll wheel scrolled
            float scrolInput = Input.GetAxis("Mouse ScrollWheel");

            // clamps the zoom between the min and the max
            currentZoom = Mathf.Clamp(currentZoom - scrolInput * zoomSpeed, minZoom, maxZoom);

            // sets the target position towards each snap point, depending on the zoom
            Vector3 targetPosition = Vector3.Lerp(firstPersonSnap.position, thirdPersonSnap.position, currentZoom / maxZoom);

            // sets the position to slowly move towards the target potition with lerping over time
            _camera.position = Vector3.Lerp(_camera.position, targetPosition, Time.deltaTime * transitionSpeed);

            // Chnages the field of view depending on how zoomed in you are
            _camera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(40, 80, currentZoom / maxZoom);
        }
    }
}

