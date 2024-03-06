using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.Jump();
        Debug.Log("Entering Jump");
    }

    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("Exiting Jump");
        //player.MoveVector.y = 0;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.MoveVector.y == 0){
            player.Jump();
            Debug.Log("Jumping at this moment...");
            player.SwitchState(player.FallingState);
        } else {
           player.SwitchState(player.IdlingState);
        }
        

        //player.Jump();

        // if (player.MoveVector.y <= 0)
        // {
        //     // Player is falling, switch to FallingState
        //     player.SwitchState(player.FallingState);
        //     Debug.Log("fall state from jump?");
        //     return;
        // } else {
        //     Debug.Log("jumping");
        //     player.Jump(); 
        // }

        // player.Move();
    }
}