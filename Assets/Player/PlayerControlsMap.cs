


// using UnityEngine;
// using UnityEngine.InputSystem;

// public partial class PlayerStateManager
// {
//     private void OnMove(InputValue value) 
//     {
//         InputVector = value.Get<Vector2>();
//         MoveVector.x = InputVector.x;
//         MoveVector.z = InputVector.y;
//     }

//     private void OnRun(InputValue value)
//     {
//         if(value.isPressed && PlayerCurrentState != FallingState){
//             SwitchState(RunningState);
//         }
//     }

//     private void OnJump(InputValue value)
//     {
//         audioSource = GetComponent<AudioSource>();
//         audioSource.Play();
//         if(PlayerCurrentState != JumpingState && PlayerCurrentState != FallingState){
//             SwitchState(JumpingState);
//         }
//     }
// }