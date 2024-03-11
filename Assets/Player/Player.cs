using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region General Object Components References
        Rigidbody rigidBody;
        CapsuleCollider capsuleCollider;
        AudioSource audioSource;
    #endregion

    #region Player Facing Direction
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public Vector3 cameraForward;
        [HideInInspector] public Vector3 cameraRight;
    #endregion

    #region Basic Variables
        [HideInInspector] public Vector2 movement;
        [HideInInspector] public bool isSprinting = false;
        public float jumpToFallTimer = 0.15f;
        public float jumpForce = 7;
        public float currentSpeed;
        public float walkSpeed = 5;
        public float runSpeed = 10;
        public float speedChangeRate = 5;
        public float rotationSpeed = 750;
        public float groundCheckRange = 0.5f;
    #endregion

    #region Object References to instance of Player States 
        public PlayerBaseState playerState;
        public PlayerIdleState idleState = new PlayerIdleState();
        public PlayerWalkState walkState = new PlayerWalkState();
        public PlayerRunState runState = new PlayerRunState();
        public PlayerFallState fallState = new PlayerFallState();
        public PlayerHitState hitState = new PlayerHitState();
    #endregion

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();
        // On Start Game Default State
        playerState = idleState; 
        playerState.EnterState(this);
    }

    void Update()
    {
        playerState.UpdateState(this);
    }

    #region Movement and Direction
        public void Movement()
        {
            // If there is no movement input, transition to the idle state
            if (movement == Vector2.zero)
            {
                ChangeState(idleState);
            }

            // Determine the current speed based on whether the player is sprinting or walking
            currentSpeed = isSprinting ? runSpeed : walkSpeed;

            // Update the player's facing direction based on the camera and input
            FaceDirection();
        }

        public void FaceDirection()
        {
            SetCameraVectors();
            CalculateMoveDirection();
            MovePlayer();
            RotatePlayer();
        }

        // Get normalized forward and right vectors of the camera
        private void SetCameraVectors() 
        {
            cameraForward = Camera.main.transform.forward.normalized;
            cameraRight = Camera.main.transform.right.normalized;
        }

        // Create a 3D vector using the horizontal and vertical input from the movement
        private void CalculateMoveDirection() => direction = new Vector3(movement.x, 0, movement.y);

        private void MovePlayer()
        {
            // Calculate the movement direction in world space
            Vector3 moveToDirection = cameraForward * direction.z + cameraRight * direction.x;

            // Move the player in the calculated direction with the current speed
            transform.Translate(currentSpeed * Time.deltaTime * moveToDirection, Space.World);
        }

        private void RotatePlayer()
        {
            // Calculate the look direction based on the camera's rotation
            Vector3 lookDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * direction;

            // Rotate the player towards the calculated look direction
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    #endregion

    public bool IsOnGroundCheck() => Physics.SphereCast(transform.position + capsuleCollider.center, capsuleCollider.radius - 0.01f, Vector3.down, out _, capsuleCollider.bounds.extents.y + groundCheckRange);

    public void ChangeState(PlayerBaseState state)
    {
        playerState.ExitState(this);
        playerState = state;
        playerState.EnterState(this);
    }

    #region New Input System Controls
        void OnMove(InputValue value) => movement = value.Get<Vector2>();

        void OnSprint(InputValue value) => isSprinting = value.isPressed;

        void OnJump()
        {
            if (playerState != fallState)
            {
                audioSource.Play();
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        void OnAttack() => ChangeState(playerState != hitState ? hitState : null);
    #endregion
}