using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{ 
    #region State Variables
    //-------------STATES-------------//
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    [SerializeField] private PlayerData playerData;
    #endregion

    #region Components

    //------------PLAYER MOVEMENT--------//
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D PlayerRB { get; private set; }
    #endregion

    #region Check Transforms
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject projectile;

    #endregion
    
    #region Other Variables
    //----------PLAYER VELOCITY-----------//
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private Vector2 workSpace; //everytime to creaty a velocity

    //---------PLAYER SHOOT-----------//

    private const int kMaxShootCount = 3;
    private int shootCount;
    public List<MoveX> projectileList = new List<MoveX>();

    #endregion

    #region Unity Callback Functions
    void Awake() {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        AirState = new PlayerAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        AttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
        
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
    public void SetVelocityY(float velocity){
        workSpace.Set(CurrentVelocity.x, velocity);
        PlayerRB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    #endregion

    #region Check Functions
    public bool CheckIfTouchingGround(){
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround); //if detected ground, return true
    }
    public void CheckIfShouldFlip(int xInput){
        if(xInput != 0 && xInput != FacingDirection){
            Flip();
        }
    }

    public void CheckIfShouldAttack(){
        if(shootCount < kMaxShootCount)
        {
            ++shootCount;
            var obj = Instantiate(projectile, transform.position, Quaternion.identity);

            var body = obj.GetComponent<MoveX>();
            projectileList.Add(body);
            body.AddVelocity(transform.right);
        }
        else
        {
            var a = projectileList.First();
            a?.FadeProjectile();
            projectileList.Remove(a);
            shootCount--;
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
