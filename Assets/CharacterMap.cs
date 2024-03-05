using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    private void OnMove(InputValue value) {
        InputVector = value.Get<Vector2>();
        MoveVector.x = InputVector.x;
        MoveVector.z = InputVector.y;
    }

    // when pressed space bar go to jumpstate
    private void OnJump(InputValue value){
        if(CurrentState != JumpingState && CurrentState != FallingState){
            SwitchState(JumpingState);
        }
    }

    private void OnRun(InputValue value){
        if(CurrentState != FallingState){
            //SwitchState(RunningState)
        }
    }
}
