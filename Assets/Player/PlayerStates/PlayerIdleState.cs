using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Entering Idle");
    }

    public override void ExitState(PlayerStateManager player) {
        Debug.Log("Exiting Idle");
    }

    public override void UpdateState(PlayerStateManager player) {
        if(player.MoveVector.magnitude != 0){
            player.SwitchState(player.WalkingState);
        }
    }
}
