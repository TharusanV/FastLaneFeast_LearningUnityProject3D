using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] //This allows us to see private variables in the inspector
    private float moveSpeed = 7f;

    // Start is called before the first frame update
    private void Start(){

    }

    // Update is called once per frame
    private void Update(){

        //Get Input
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

        //Move object - Changing the transform directly is more easier than using physics
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); //To move backwards and forwards instead of using Y we use Z
        transform.position += moveDir * moveSpeed * Time.deltaTime; //We multiply the Time.deltaTime with the direction and speed-multiplier to make the movemenet consistent no matter have fast a monitors frame rate
        
        //Rotate to look are the direction facing 
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //Smoothing with lerp so the rotation is more natural
    }
}
