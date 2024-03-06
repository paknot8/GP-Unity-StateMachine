using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float jumpForce = 0.1f;
    private float maxForce = 10f;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Jump");
    }

    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("Exiting Jump");
        player.MoveVector.y = 0;
    }

    public override void UpdateState(PlayerStateManager player)
    {  
       player.MoveVector.y += jumpForce;

       if(player.MoveVector.y >= maxForce)
       {
            player.SwitchState(player.FallingState);
       }

       player.Move();
    }
}
