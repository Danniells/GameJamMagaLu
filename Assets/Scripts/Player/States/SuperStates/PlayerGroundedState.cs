using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    private bool JumpInput;
    private bool isGrounded;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Checks()
    {
        base.Checks();
        isGrounded = player.CheckIfTouchingGround();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    public override void Update()
    {
        base.Update();
        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;

        if(JumpInput){
            player.InputHandler.UseJumpInput();
            stateMachine.SwitchState(player.JumpState);
        } else if(!isGrounded){
            stateMachine.SwitchState(player.AirState); // the player dont get stuck in walls
        }
    }
}
