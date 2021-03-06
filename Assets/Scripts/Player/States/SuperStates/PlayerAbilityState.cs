using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    private bool isGrounded;
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        isAbilityDone = false;
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

        if(isAbilityDone){
            if(isGrounded && player.CurrentVelocity.y < 0.01f){
                stateMachine.SwitchState(player.IdleState);
            }
            else{
                stateMachine.SwitchState(player.AirState);
            }
        } 
    }
}
