using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractObjects : MonoBehaviour
{

    [SerializeField] private PlayerGameInput playerInput; 
    private Vector3 lastInteractDir;
    [SerializeField] private LayerMask counter_LayerMask;

    private ClearCounterScript closestCounter;


    // Start is called before the first frame update
    void Start(){
        playerInput.OnInteractAction += OnInteractAction; //References the function
    }

    // Update is called once per frame
    void Update(){
         HandleClosestInteractions();
    }

    private void HandleClosestInteractions() {
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //We need this as if the player is not moving in any direction, then a raycast would still be made by using the last recorded direction
        if (moveDir != Vector3.zero) {
            lastInteractDir = moveDir;
        }

        float interactDistance = 1f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counter_LayerMask)) {
            //Specify 'out' means its an output paramater, by default all paramaters are input

            ClearCounterScript clearCounter = raycastHit.transform.GetComponent<ClearCounterScript>();
            if (clearCounter != null) { 
                //Has Clear Counter
                if(clearCounter != closestCounter){
                    closestCounter = clearCounter;
                }
            }
            else{
                closestCounter = null;
            }
        }
        else{
            closestCounter = null;
        }

        //Debug.Log(closestCounter);
    }

    private void OnInteractAction(object sender, System.EventArgs e) {
        if(closestCounter != null){
            closestCounter.Interact(closestCounter);
        }
    }

}
