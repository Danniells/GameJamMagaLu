using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    private int xInput;
    private bool isGrounded;
    private bool ShootInput;
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        ShootInput = player.InputHandler.ShootInput;
        

        if(isGrounded && player.CurrentVelocity.y < 0.01f){
            stateMachine.SwitchState(player.LandState);
        }
        else if(!isGrounded || ShootInput){
            player.CheckIfShouldFlip(xInput);
            stateMachine.SwitchState(player.AttackState);
            //player.SetVelocityX(playerData.movementVelocity * xInput); //returns to move in air
            
            player.Anim.SetTrigger("inAir");
        }

        //if(ShootInput)
    }
}
