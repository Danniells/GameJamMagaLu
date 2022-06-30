using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    #region State Variables
    //-------------STATES-------------//
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    [SerializeField] private PlayerData playerData;
    #endregion

    #region Components
    //------------PLAYER MOVEMENT--------//
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D PlayerRB { get; private set; }
    #endregion

    #region Other Variables
    //----------PLAYER VELOCITY-----------//
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private Vector2 workSpace; //everytime to creaty a velocity
    #endregion

    #region Unity Callback Functions
    void Awake() {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
    }

    void Start(){
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        PlayerRB = GetComponent<Rigidbody2D>();

        FacingDirection = 1;
        
        StateMachine.Initialize(IdleState);
    }

    void Update(){
        StateMachine.CurrentState.Update();
        CurrentVelocity = PlayerRB.velocity;
    }

    void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity){
        workSpace.Set(velocity, CurrentVelocity.y);
        PlayerRB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    #endregion

    #region Check Functions
    public void CheckIfShouldFlip(int xInput){
        if(xInput != 0 && xInput != FacingDirection){
            Flip();
        }
    }
    #endregion

    #region Other Functions
    void Flip(){
        FacingDirection *= -1;
        transform.Rotate(0f, 180.0f, 0f);
    }
    #endregion
    
}
