using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] //This allows us to see private variables in the inspector
    private float moveSpeed = 7f;

    [SerializeField] //This allows us to see private variables in the inspector
    private PlayerInput playerInput;


    private bool isWalking;

    private void Awake(){
        isWalking = false;
    }

    // Update is called once per frame
    private void Update(){
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
       
        //Move object - Changing the transform directly is more easier than using physics
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //To move backwards and forwards instead of using Y we use Z
        transform.position += moveDir * moveSpeed * Time.deltaTime; //We multiply the Time.deltaTime with the direction and speed-multiplier to make the movemenet consistent no matter have fast a monitors frame rate
        
        isWalking = moveDir != Vector3.zero;

        //Rotate to look are the direction facing 
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //Smoothing with lerp so the rotation is more natural
    }

    public bool IsPlayerWalking(){
        return isWalking;
    }
}
