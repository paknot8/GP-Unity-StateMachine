using UnityEngine;
using UnityEngine.InputSystem;

// TODO - Change color for Sprint, idle, Jumping
// TODO - Make Level
// TODO - Pick up coins
// TODO - Score Board
// TODO EXTRA - Enemy AI

public partial class PlayerStateManager : MonoBehaviour
{
    private void Awake(){
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        PlayerSpeed = 10f;
        PlayerRotateSpeed = 100;
        _gravityVector = new Vector3(0 ,-9.81f, 0);
    }

    void Start(){
        CurrentState = IdlingState; // start with this state
        CurrentState.EnterState(this);
    }

    #region Movement
    void Update()
    {
        if(CurrentState != FallingState && !Controller.isGrounded){
            SwitchState(FallingState);
        }
        CurrentState.UpdateState(this);
        ApplyGravity();
    }

    public void SwitchState(PlayerBaseState state){
        CurrentState.ExitState(this);
        CurrentState = state;
        state.EnterState(this);
    }

    public void ApplyGravity()
    {
        Controller.Move(_gravityVector * Time.deltaTime);
    }

    public void Move()
    {
        Controller.Move(PlayerSpeed * Time.deltaTime * MoveVector);
        RotateTowardsVector(); // when player is moving it updates the rotation;
    }

    public void RotateTowardsVector()
    {
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z); // Look at direction
        if(xzDirection.magnitude == 0) return; // check if it's 0 no new point

        var rotation = Quaternion.LookRotation(xzDirection); // Help create rotation can be applied to vectors
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed); // Make feel the controller feel snappy and responsive
    }
    #endregion
}