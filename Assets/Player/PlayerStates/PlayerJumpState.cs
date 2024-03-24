using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(Player player)
    { 
        if (player.IsGrounded())
        {
            // Red
            player.GetComponent<MeshRenderer>().material.color = new Color32(250, 00, 45, 255);
            player.rigidBody.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
            player.jumpSound.Play();
        }
        Debug.Log("Jump State");
    }

    public override void ExitState(Player player){}

    public override void UpdateState(Player player)
    {
        if (!player.IsGrounded()) player.ChangeState(player.fallState);
    }
}
