using UnityEngine;
using UnityEngine.InputSystem;

// This is a partial class with only variables in Player to seperate the variables and methods for better readablity
public partial class Player
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
        public float jumpCooldown = 1.0f;
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
}