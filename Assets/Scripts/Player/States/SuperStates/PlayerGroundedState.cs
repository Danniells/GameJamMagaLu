using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    private bool JumpInput;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Checks()
    {
        base.Checks();
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
        }
    }
}
