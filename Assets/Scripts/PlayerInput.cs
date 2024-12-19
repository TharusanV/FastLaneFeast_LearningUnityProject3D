using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions ;
    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        /*
        Old Version before using Input System Package
        Vector2 inputVector = new Vector2(0, 0); //Vector2 refers to the X and Y, typically used in 2d games
        
        if (Input.GetKey (KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey (KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey (KeyCode.D)) {
            inputVector.x = +1;
        }
        */

        inputVector = inputVector.normalized; //If we didn't add this then the player would move faster diagonally than if they went in one direction, so normalising it makes it the same throughout

        return inputVector;
    }
}
