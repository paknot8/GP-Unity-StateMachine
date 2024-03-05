using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    private void OnMove(InputValue value) {
        InputVector = value.Get<Vector2>();
        MoveVector.x = InputVector.x;
        MoveVector.z = InputVector.y;

        Debug.Log($"X move: {MoveVector.x}");
        Debug.Log($"Z move: {MoveVector.z}");
        Debug.Log("Moving...");
    }

    private void OnJump(InputValue value){
        if(value.isPressed){
            
        }
    }

    private void OnRun(InputValue value){
        if(value.isPressed){
        }
    }
}
