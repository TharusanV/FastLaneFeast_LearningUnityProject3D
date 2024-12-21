using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f; //This allows us to see private variables in the inspector
    [SerializeField] private PlayerGameInput playerInput; 
    private bool isWalking;

  

    private void Awake(){
        isWalking = false;
    }

    private void Start(){
        
    }

    // Update is called once per frame
    private void Update(){
        HandleMovement();
    }

    public bool IsPlayerWalking(){
        return isWalking;
    }

    private void HandleMovement(){
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
       
        //Move object - Changing the transform directly is more easier than using physics
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //To move backwards and forwards instead of using Y we use Z
        
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance); //A capsulecast is a psychics operation that fires a lazer in the shape of a capsule (there are other types like ray, box, ect) from a certain point towards a certain direction and tells you if it hits something
        
        if(!canMove){ //Cannot move towards moveDir e.g. collision
            
            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if(canMove){//Can move only on the X
                moveDir = moveDirX;
            }
            else{//Cannot move only on the X

                //Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0,0,moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
            
                if(canMove){//Can move only on the Z
                    moveDir = moveDirZ;
                }
                else{
                    //Cannot move in any direction
                }
            }
        }

        if(canMove){
            transform.position += moveDir * moveSpeed * Time.deltaTime; //We multiply the Time.deltaTime with the direction and speed-multiplier to make the movemenet consistent no matter have fast a monitors frame rate
        }

        isWalking = moveDir != Vector3.zero;

        //Rotate to look are the direction facing 
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //Smoothing with lerp so the rotation is more natural
    }

    


 



}
