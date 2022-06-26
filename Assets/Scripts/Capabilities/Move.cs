using UnityEngine;
using Shinjingi;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Controller))]
public class Move : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;

    private Controller _controller;
    private Vector2 _direction, _desiredVelocity, _velocity;
    private Rigidbody2D _body;
    private Ground _ground;
    private SpriteRenderer characterSprite;
    private float _maxSpeedChange, _acceleration;
    private bool _onGround;


    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
        _controller = GetComponent<Controller>();
        
        shootCount = 0;
    }

    private void Update()
    {
        _direction.x = _controller.input.RetrieveMoveInput();
        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _ground.Friction, 0f);
        
        if(_controller.input.RetrieveShootInput()) FireProjectile();

        if(_direction.x < 0) transform.localScale = new Vector3(-1f, 1f, 1f);
        else transform.localScale = Vector3.one * 1f;
    }

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _maxSpeedChange = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;
    }
    
    [Header("PROJECTILE")]  
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform aimPoint;
    private const int kMaxShootCount = 3;
    [SerializeField]private int shootCount;
    public List<MoveX> projectileList = new List<MoveX>();

    private void FireProjectile()
    {
        var isLeft = _direction.x < 0;

        if(shootCount < kMaxShootCount)
        {
            var obj = Instantiate(projectile, aimPoint.position, Quaternion.identity);

            var body = obj.GetComponent<MoveX>();
            projectileList.Add(body);
            body.AddVelocity(isLeft, transform.right);
            
            if(isLeft) body.projectileSprite.flipX = true;
            shootCount++;
        }
        else
        {
            var a = projectileList.First();
            a.FadeProjectile();
            projectileList.Remove(a);
            shootCount--;
        }
    }

}
