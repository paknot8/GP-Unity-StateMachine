using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        //Debug.Log("Entering Running");
    }

    public override void ExitState(PlayerStateManager player) {
        //Debug.Log("Exiting Running");
    }

    public override void UpdateState(PlayerStateManager player) {
        if(player.MoveVector.magnitude == 0){
            player.SwitchState(player.IdlingState);
        } else {
            player.Run();
            Debug.Log("Running right now...");
        }
    }
}