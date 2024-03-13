using UnityEngine;
using UnityEngine.InputSystem;

// This is the main class with a partial class with better readablity there is a PlayerVariables.cs to store all the variables.
public partial class Player : MonoBehaviour
{
    // On Game Start
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        jumpSound = GetComponent<AudioSource>();
        // On Start Game Default State
        playerState = idleState;
        playerState.EnterState(this);
        jumpSound.volume = 0.1f;
    }

    // Checking what state it is the whole time.
    void Update() => playerState.UpdateState(this); 

    #region Movement and Direction for player to Face Forward
        public void PlayerMovement()
        {
            // If there is no movement input, transition to the idle state
            if (movement == Vector2.zero)
                ChangeState(idleState);

            currentSpeed = isSprinting ? runSpeed : walkSpeed;
            FaceDirection();
        }

        // Using Extra Methode so it is better readable
        public void FaceDirection()
        {
            SetCameraVectorsAndNormalize();
            CalculateMoveDirection();
            MovementOfPlayer();
            RotatePlayer();
        }

        // Get normalized forward and right vectors of the camera
        private void SetCameraVectorsAndNormalize() 
        {
            cameraForward = Camera.main.transform.forward.normalized;
            cameraRight = Camera.main.transform.right.normalized;
        }

        // Create a 3D vector using the horizontal and vertical input from the movement
        private void CalculateMoveDirection() => direction = new Vector3(movement.x, 0, movement.y);

        // Calculate the movement direction in world space
        // Move the player in the calculated direction with the current speed
        private void MovementOfPlayer()
        {
            moveToDirection = cameraForward * direction.z + cameraRight * direction.x; 
            transform.Translate(currentSpeed * Time.deltaTime * moveToDirection, Space.World);
        }

        private void RotatePlayer()
        {
            // Calculate the look direction based on the camera's rotation
            lookToDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * direction;

            // Check if lookDirection is close to zero, Skip rotation when lookDirection is close to zero
            if (lookToDirection.sqrMagnitude < 0.0001f) return; 

            // Rotate the player towards the calculated look direction
            rotation = Quaternion.LookRotation(lookToDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    #endregion

    #region General Methods
        // Checks for if player is grounded
        public bool IsGrounded()
        {
            float sphereRadius = capsuleCollider.radius - 0.01f; // Adjust the offset as needed
            float sphereCastDistance = capsuleCollider.bounds.extents.y + 0.2f; // Adjust the distance as needed

            // Cast sphere downwards from the center of the capsule collider (check collision on ground)
            return Physics.SphereCast(transform.position + capsuleCollider.center, sphereRadius, Vector3.down, out _, sphereCastDistance);
        }
        
        // Functions as State Changer
        public void ChangeState(PlayerBaseState state)
        {
            playerState.ExitState(this);
            playerState = state;
            playerState.EnterState(this);
        }
    #endregion

    #region New Input System Controls
        void OnMove(InputValue value) => movement = value.Get<Vector2>();

        void OnSprint(InputValue value) => isSprinting = value.isPressed;

        void OnJump(InputValue value){
            if(value.isPressed && isSprinting){
                ChangeState(jumpState);
            }
        }
    #endregion
}