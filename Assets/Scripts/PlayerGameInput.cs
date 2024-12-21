using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //This is an example of an event, which essentially doesn't work on every update but instead notfies the subscribers when an event has triggered
        //In this case, performed is the event. To subscribe to it we use += which acts as a listener
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // -> Old Input system would be here

        inputVector = inputVector.normalized; //If we didn't add this then the player would move faster diagonally than if they went in one direction, so normalising it makes it the same throughout

        return inputVector;
    }

    //When 'e' key is pressed do this essentially
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        //First check if there are an listeners
        if(OnInteractAction != null){
            OnInteractAction(this, EventArgs.Empty);
        }
    }

    /////////////////////////////////////////////////Disregard this old code/////////////////////////////////////////////////////////////
    private Vector2 OldInputSystem(){
        //Old Version before using Input System Package
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
        
        inputVector = inputVector.normalized; //If we didn't add this then the player would move faster diagonally than if they went in one direction, so normalising it makes it the same throughout

        return inputVector;
    }
}
