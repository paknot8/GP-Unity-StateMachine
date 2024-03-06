using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    #region States
        public PlayerWalkState WalkingState = new PlayerWalkState();
        public PlayerRunState RunningState = new PlayerRunState();
        public PlayerIdleState IdlingState = new PlayerIdleState();
        public PlayerFallState FallingState = new PlayerFallState();
        public PlayerJumpState JumpingState = new PlayerJumpState();
    #endregion

    public CharacterController Controller;
    public PlayerInput Input;
    public PlayerBaseState PlayerCurrentState;
    public AudioSource audioSource;

    public Vector3 MoveVector;
    public Vector2 InputVector;
    public float PlayerSpeed;
    public float PlayerSpeedMultiplier;
    public float PlayerRotateSpeed;
    private Vector3 _gravityVector;
}