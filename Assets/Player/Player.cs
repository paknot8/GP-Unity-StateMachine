using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region General Object Components References
        [HideInInspector] public Rigidbody rigidBody;
        [HideInInspector] public CapsuleCollider capsuleCollider;
        [HideInInspector] public AudioSource jumpSound;
    #endregion

    #region Player Movements
        // --- Vector 3 --- //
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public Vector3 moveToDirection;
        [HideInInspector] public Vector3 lookToDirection;
        [HideInInspector] public Vector3 cameraForward;
        [HideInInspector] public Vector3 cameraRight;
        //  --- Vector 2 ---  //
        [HideInInspector] public Vector2 movement;
        //  --- Quaternion ---  //
        [HideInInspector] public Quaternion rotation;
    #endregion

    #region Basic Variables
        [HideInInspector] public bool isSprinting = false;
        public float jumpForce = 7f;
        public float forwardJumpForce = 4f;
        public float currentSpeed = 0f;
        public float walkSpeed = 4f;
        public float runSpeed = 10f;
        public float speedChangeRate = 5f;
        public float rotationSpeed = 750f;
        public float groundCheckRange = 0.5f;
    #endregion

    #region Object References to Player States 
        public PlayerBaseState playerState;
        public PlayerIdleState idleState = new();
        public PlayerWalkState walkState = new();
        public PlayerRunState runState = new();
        public PlayerFallState fallState = new();
        public PlayerJumpState jumpState = new();
    #endregion

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
            float sphereRadius = capsuleCollider.radius - 0.01f; // Adjust the offset as needed
            float sphereCastDistance = capsuleCollider.bounds.extents.y + 0.2f; // Adjust the distance as needed

            // Cast sphere downwards from the center of the capsule collider (check collision on ground)
            return Physics.SphereCast(transform.position + capsuleCollider.center, sphereRadius, Vector3.down, out _, sphereCastDistance);
        }
        
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