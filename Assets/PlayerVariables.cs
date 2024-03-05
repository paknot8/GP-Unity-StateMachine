using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    #region ConcreteStates
    public WalkState WalkingState = new WalkState();
    public IdleState IdlingState = new IdleState();
    public FallState FallingState = new FallState();
    #endregion

    public CharacterController Controller;
    public PlayerInput Input;
    public PlayerBaseState CurrentState;

    public Vector3 MoveVector;
    public Vector2 InputVector;
    public float PlayerSpeed;
    public float PlayerRotateSpeed;
    private Vector3 _gravityVector;
}