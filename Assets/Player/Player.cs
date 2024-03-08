using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region Object Components Reference
        Rigidbody rigidBody;
        CapsuleCollider capsuleCollider;
    #endregion

    #region Basic Variables
        [HideInInspector] public Vector2 movement;
        [HideInInspector] public bool isSprinting = false;
        public float jumpToFallTimer = 0.15f;
        public float jumpForce = 7;
        public float walkSpeed = 5;
        public float runSpeed = 10;
        public float speedChangeRate = 5;
        public float rotationSpeed = 750;
        public float groundCheckRange = 0.5f;
    #endregion

    #region Player States
        public PlayerBaseState playerState;
        public PlayerIdleState idleState = new PlayerIdleState();
        public PlayerWalkState walkState = new PlayerWalkState();
        public PlayerRunState runState = new PlayerRunState();
        public PlayerFallState fallState = new PlayerFallState();
        public PlayerHitState hitState = new PlayerHitState();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        
        playerState = idleState;
        playerState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        playerState.UpdateState(this);
    }
    
    public void Movement()
    {
        if (movement == Vector2.zero){
            ChangeState(idleState);
        }

        float currentSpeed;
        if (isSprinting)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        Vector3 direction = new(movement.x, 0, movement.y);

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 moveDirection = cameraForward * direction.z + cameraRight * direction.x;

        transform.Translate(currentSpeed * Time.deltaTime * moveDirection, Space.World);

        Vector3 lookDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * direction;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnSprint(InputValue value)
    {
        if (value.isPressed)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    void OnJump()
    {
        if(playerState != fallState)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnAttack()
    {
        if (playerState != hitState)
        {
            ChangeState(hitState);
        }
    }

    public bool IsOnGroundCheck()
    {
        return Physics.Raycast(transform.position + capsuleCollider.center, Vector3.down, capsuleCollider.bounds.extents.y + groundCheckRange);
    }

    public void ChangeState(PlayerBaseState state)
    {
        playerState.ExitState(this);
        playerState = state;
        playerState.EnterState(this);
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        
    }

    private void OnLand(AnimationEvent animationEvent)
    {
       
    }
}




// using UnityEngine;
// using UnityEngine.InputSystem;

// public partial class PlayerStateManager : MonoBehaviour
// {
//     private void Awake(){
        
//         Controller = GetComponent<CharacterController>();
//         Input = GetComponent<PlayerInput>();
//         PlayerSpeed = 5f;
//         PlayerSpeedMultiplier = 2f;
//         PlayerRotateSpeed = 750;
//         _gravityVector = new Vector3(0, -1F, 0);
//     }

//     void Start(){
//         PlayerCurrentState = IdlingState; // start with this state
//         PlayerCurrentState.EnterState(this);
//     }

//     void Update()
//     {
//         if(PlayerCurrentState != FallingState && PlayerCurrentState != JumpingState && !Controller.isGrounded)
//         {
//             SwitchState(FallingState);
//         }
//         PlayerCurrentState.UpdateState(this);
//         ApplyGravity();
//     }

//     #region Movement
//     public void SwitchState(PlayerBaseState state){
//         PlayerCurrentState.ExitState(this);
//         PlayerCurrentState = state;
//         state.EnterState(this);
//     }

//     public void ApplyGravity()
//     {
//         Controller.Move(PlayerSpeed * Time.deltaTime * MoveVector);
//         Controller.Move((_gravityVector += Physics.gravity * Time.deltaTime) * Time.deltaTime);
//     }

//     public void Move()
//     {
//         Controller.Move(PlayerSpeed * Time.deltaTime * MoveVector);
//         RotateTowardsVector(); // when player is moving it updates the rotation;
//     }

//     public void Run(){
//         Controller.Move(PlayerSpeed * PlayerSpeedMultiplier * Time.deltaTime * MoveVector);
//         RotateTowardsVector();
//     }

//     public void RotateTowardsVector()
//     {
//         Vector3 xzDirection = new(MoveVector.x, 0, MoveVector.z);

//         if (xzDirection.magnitude != 0)
//         {
//             Quaternion rotation = Quaternion.LookRotation(xzDirection);
//             transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed * Time.deltaTime);
//         }
//     }
//     #endregion

//     #region  Jumping
//     public void Jump(){
//         Vector3 goUp = new(0, MoveVector.y, 0);
//         Controller.Move(goUp);
//     }

//     public void ResetVerticalMovement()
//     {
//         MoveVector.y = 0;
//     }
// #endregion
// }