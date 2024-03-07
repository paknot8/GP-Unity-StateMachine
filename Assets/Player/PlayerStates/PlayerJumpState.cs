using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerJumpState : PlayerBaseState
{
    // private float jumpForce = 0.1f;
    // private float maxForce = 10f;

    Rigidbody rigidbody;

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
<<<<<<< HEAD
        if(player.MoveVector.y == 0)
        {
            player.Jump();
            Debug.Log("Jumping at this moment... in de state");
            player.SwitchState(player.FallingState);
        } 
        else 
        {
           player.SwitchState(player.IdlingState);
        }
        


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

        // player.Walk();
=======
    
    //    player.MoveVector.y += jumpForce;

    //    if(player.MoveVector.y >= maxForce)
    //    {
    //         player.SwitchState(player.FallingState);
    //    }

    //    player.Move();
>>>>>>> parent of da0a472 (Everything works fine, only Jumpstate not working.)
    }
}
