using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] Rigidbody2D body;


    public void AddVelocity(Vector2 force) => body?.AddForce(force * speed, ForceMode2D.Impulse);
}
