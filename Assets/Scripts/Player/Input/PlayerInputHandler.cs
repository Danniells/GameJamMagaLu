using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    //-------MOVEMENT--------/
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    //---------JUMP--------//
    public bool JumpInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context){
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context){
        if(context.started) { //means that jump button has pushed down
            JumpInput = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;
    

    public void OnShootInput(InputAction.CallbackContext context){
        Debug.Log("shoot input");
    }
}
