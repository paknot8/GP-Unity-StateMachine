using UnityEngine;

public class WalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Entering Walking");
    }

    public override void ExitState(PlayerStateManager player) {
        Debug.Log("Exiting Walking");
    }

    public override void UpdateState(PlayerStateManager player) {
        if(player.MoveVector.magnitude == 0){
            player.SwitchState(player.IdlingState);
        } else {
            player.Move();
        }
    }
}
