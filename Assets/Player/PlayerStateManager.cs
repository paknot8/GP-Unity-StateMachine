using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    private void Awake(){
        rb = GetComponent<Rigidbody>();
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        PlayerSpeed = 5f;
        PlayerSpeedMultiplier = 2f;
        PlayerRotateSpeed = 100;
        _gravityVector = new Vector3(0, -1.0F, 0);
        JumpForce = 10f;
    }

    void Start(){
        PlayerCurrentState = IdlingState; // start with this state
        PlayerCurrentState.EnterState(this);
    }

    #region Movement
    void Update()
    {
        if(PlayerCurrentState != FallingState 
        && PlayerCurrentState != JumpingState 
        && !Controller.isGrounded)
        {
            SwitchState(FallingState);
        }
        PlayerCurrentState.UpdateState(this);
        ApplyGravity();
    }

    public void SwitchState(PlayerBaseState state){
        PlayerCurrentState.ExitState(this);
        PlayerCurrentState = state;
        state.EnterState(this);
    }

    public void ApplyGravity()
    {
        Controller.Move((_gravityVector += Physics.gravity * Time.deltaTime) * Time.deltaTime);
    }

    public void Walk()
    {
        Controller.Move(PlayerSpeed * Time.deltaTime * MoveVector);
        RotateTowardsVector(); // when player is moving it updates the rotation;
    }

    public void Run(){
        Controller.Move(PlayerSpeed * PlayerSpeedMultiplier * Time.deltaTime * MoveVector);
        RotateTowardsVector();
    }

    public void Jump(){
        if(!Controller.isGrounded){
             rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); 
             Debug.Log("Function call Jump");
        }
    }

    public void RotateTowardsVector()
    {
        Vector3 xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);

        if (xzDirection.magnitude != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(xzDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed);
        }
    }
    #endregion
}