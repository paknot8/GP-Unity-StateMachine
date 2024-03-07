using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    private void Awake(){
        
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        PlayerSpeed = 5f;
        PlayerSpeedMultiplier = 2f;
<<<<<<< HEAD
        PlayerRotateSpeed = 1000f; // for rotation
        JumpForce = 10f;
=======
        PlayerRotateSpeed = 100;
        _gravityVector = new Vector3(0, -1.0F, 0);
>>>>>>> parent of da0a472 (Everything works fine, only Jumpstate not working.)
    }

    void Start(){
        PlayerCurrentState = IdlingState; // start with this state
        PlayerCurrentState.EnterState(this);
    }

    #region Movement
    void Update()
    {
        if(PlayerCurrentState != FallingState && PlayerCurrentState != JumpingState && !Controller.isGrounded)
        {
            SwitchState(FallingState);
        }
        PlayerCurrentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state){
        PlayerCurrentState.ExitState(this);
        PlayerCurrentState = state;
        state.EnterState(this);
    }

<<<<<<< HEAD
    public void Walk()
=======
    public void ApplyGravity()
    {
        Controller.Move((_gravityVector += Physics.gravity * Time.deltaTime) * Time.deltaTime);
    }

    public void Move()
>>>>>>> parent of da0a472 (Everything works fine, only Jumpstate not working.)
    {
        Controller.Move(PlayerSpeed * Time.deltaTime * MoveVector);
        RotateTowardsVector(); // when player is moving it updates the rotation;
    }

    public void Run(){
        Controller.Move(PlayerSpeed * PlayerSpeedMultiplier * Time.deltaTime * MoveVector);
        RotateTowardsVector();
    }

    public void Jump(){
        //if(PlayerCurrentState != FallingState) .AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //if(playerState != fallState) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void RotateTowardsVector()
    {
<<<<<<< HEAD
        Vector3 xzDirection = new(MoveVector.x, 0, MoveVector.z);

        if (xzDirection.magnitude != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(xzDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed * Time.deltaTime);
        }
=======
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z); // Look at direction
        if(xzDirection.magnitude == 0) return; // check if it's 0 no new point
        var rotation = Quaternion.LookRotation(xzDirection); // Help create rotation can be applied to vectors
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed); // Make feel the controller feel snappy and responsive
>>>>>>> parent of da0a472 (Everything works fine, only Jumpstate not working.)
    }
    #endregion
}