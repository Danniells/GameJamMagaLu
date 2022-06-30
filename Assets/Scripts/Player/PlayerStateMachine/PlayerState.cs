using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{   
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    
    protected float startTime;
    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName){
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter(){
        Checks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
    }

    public virtual void Exit(){
        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void Update(){

    }

    public virtual void PhysicsUpdate(){
        Checks();
    }

    public virtual void Checks(){ //look for ground , look for walls, etc...

    }
}
