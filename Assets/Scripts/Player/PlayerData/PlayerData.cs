using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject //allows to create assets from the script
{
    [Header("Move State")]
    public float movementVelocity = 10;

    [Header("Jump State")]
    public float jumpVelocity = 7f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
}
