using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Entering Falling");
    }

    public override void ExitState(PlayerStateManager player) {
        Debug.Log("Exiting Falling");
    }

    public override void UpdateState(PlayerStateManager player) {
        if(player.Controller.isGrounded){
            player.SwitchState(player.IdlingState);
        } else {
            player.Move();
        }
    }
}