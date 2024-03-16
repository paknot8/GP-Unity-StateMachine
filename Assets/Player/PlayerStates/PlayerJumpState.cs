using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(Player player)
    { 
        if (player.IsGrounded())
        {
            player.jumpSound.Play();
            ForceUpAndForward(player);
            // Red
            player.GetComponent<MeshRenderer>().material.color = new Color32(250, 00, 45, 255);
        }
        Debug.Log("Jump State");
    }

    public override void ExitState(Player player){}

    public override void UpdateState(Player player)
    {
        if (!player.IsGrounded())
            player.ChangeState(player.fallState);
    }

    // Apply forward force for the jump
    private void ForceUpAndForward(Player player)
    {
        player.rigidBody.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        player.rigidBody.AddForce(player.transform.forward * player.forwardJumpForce, ForceMode.Impulse);
    }
}
