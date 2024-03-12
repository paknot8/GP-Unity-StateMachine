using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(Player player)
    { 
        if (player.IsGrounded()){
            Debug.Log("Enter Jumping");
            player.jumpSound.Play();
            player.rigidBody.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
            player.GetComponent<MeshRenderer>().material.color = new Color32(250, 99, 45, 255); // Orange
        } 
    }

    public override void ExitState(Player player)
    {
        Debug.Log("Exit Jumping");
    }

    public override void UpdateState(Player player)
    {
        if (!player.IsGrounded())
        {
            Debug.Log("go to fall state...");
            player.ChangeState(player.fallState);
        }
    }
}
