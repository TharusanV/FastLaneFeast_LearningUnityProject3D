using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractObjects : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private PlayerGameInput playerInput; 
    private Vector3 lastInteractDir;
    [SerializeField] private LayerMask counter_LayerMask;

    private ParentClass_Counter closestCounter;

    public event EventHandler<OnClosestCounterChangeEventArgs> OnClosestCounterChange; //Define an event


    private KitchenObject kitchenObject;
    [SerializeField] private Transform itemHoldPoint;


    // Start is called before the first frame update
    void Start(){
        playerInput.OnInteractAction += OnInteractAction; //References the function
    }

    // Update is called once per frame
    void Update(){
         HandleClosestInteractions();
    }

    public class OnClosestCounterChangeEventArgs : EventArgs{
        public ParentClass_Counter closestCounterRef;
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

            ParentClass_Counter anyCounter = raycastHit.transform.GetComponent<ParentClass_Counter>();
            if (anyCounter != null) { 
                //Has a Counter
                if(anyCounter != closestCounter){
                    SetClosestCounter(anyCounter);
                }
            }
            else{
                SetClosestCounter(null);

            }
        }
        else{
            SetClosestCounter(null);
        }

        //Debug.Log(closestCounter);
    }

    private void OnInteractAction(object sender, System.EventArgs e) {
        if(closestCounter != null){
            closestCounter.Interact(this);
        }
    }

    private void SetClosestCounter(ParentClass_Counter selectedCounter){
        this.closestCounter = selectedCounter;

        if(OnClosestCounterChange != null){ 
            //We are checking if there are any listeners at all, if there are then send if there isn't then there is no point
            //You can remove this entire block to do the same thing and just do OnClosestCounterChange?.Invoke(this, EventArgs.Empty);
            OnClosestCounterChange(this, new OnClosestCounterChangeEventArgs{closestCounterRef = closestCounter});
        }
    }





    public Transform GetItemPlacementTransform(){
        return itemHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }

    public void ClearKitchenObject(){
        kitchenObject = null;
    }

    public bool HasKitchenObject(){
        return kitchenObject != null;
    }
    

}
