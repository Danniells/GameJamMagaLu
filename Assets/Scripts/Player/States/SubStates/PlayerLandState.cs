using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if(xInput != 0){
            stateMachine.SwitchState(player.MoveState);
        }else{
            stateMachine.SwitchState(player.IdleState);
        }
    }
}
