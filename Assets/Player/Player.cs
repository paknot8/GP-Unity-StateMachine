using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// This is the main class with a partial class 
// with better readablity there is a PlayerVariables.cs to store all the variables.
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
        public bool IsGrounded()
        {
            // Offset the origin of the raycasts from the center of the capsule collider to the corners
            // Detect ground even when the capsule is on an uneven surface
            // The offsets are based on the size of the capsule collider
            Vector3 cornerOffset1 = new(0.4f, 0.0f, -0.4f);
            Vector3 cornerOffset2 = new(-0.4f, 0.0f, 0.4f);
            Vector3 cornerOffset3 = new(-0.4f, 0.0f, -0.4f);
            Vector3 cornerOffset4 = new(0.4f, 0.0f, 0.4f);

            // 4 raycasts from the corners of the capsule collider downwards to check for ground
            // If any of the raycasts hit an object within the specified distance, return true
            // The distance value is based on the size of the capsule collider and ground detection.
            bool grounded = Physics.Raycast(transform.position + capsuleCollider.center + cornerOffset1, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f) ||
                            Physics.Raycast(transform.position + capsuleCollider.center + cornerOffset2, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f) ||
                            Physics.Raycast(transform.position + capsuleCollider.center + cornerOffset3, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f) ||
                            Physics.Raycast(transform.position + capsuleCollider.center + cornerOffset4, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
            return grounded;
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

        void OnSprint(InputValue value) => isSprinting = value.isPressed; // when pressed sprinting = true

        void OnJump(InputValue value){
            if(value.isPressed && isSprinting)
                ChangeState(jumpState);
        }
    #endregion
}
