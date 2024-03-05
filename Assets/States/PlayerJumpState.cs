using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float JumpForce = .1f;
    private int MaxForce = 10;

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
       player.MoveVector.y += JumpForce;

    // Naar boven
       if(player.MoveVector.y >= MaxForce)
       {
            player.SwitchState(player.FallingState);
       }

       player.Move();
    }
}
