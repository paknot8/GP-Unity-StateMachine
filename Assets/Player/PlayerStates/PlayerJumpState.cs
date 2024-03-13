using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(Player player)
    { 
        if (player.IsGrounded()){
            player.jumpSound.Play();
            player.rigidBody.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
            // Add forward force
            player.rigidBody.AddForce(player.transform.forward * player.forwardJumpForce, ForceMode.Impulse);
            // Red - indicates has jumped
            player.GetComponent<MeshRenderer>().material.color = new Color32(250, 00, 45, 255);
        }
    }

    public override void ExitState(Player player){}

    public override void UpdateState(Player player)
    {
        if (!player.IsGrounded())
        {
            player.ChangeState(player.fallState);
        }
    }
}
