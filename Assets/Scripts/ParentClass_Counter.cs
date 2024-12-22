using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentClass_Counter : MonoBehaviour, IKitchenObjectParent{

    [SerializeField] private Transform itemPlacement;
    private KitchenObject kitchenObject;

    public virtual void Interact(PlayerInteractObjects player) {
        //Virtual means that is has to be defined/override itself when used similar to abstract but less complex
        Debug.LogError("BaseCounter.Interact();");
    }



    public Transform GetItemPlacementTransform(){
        return itemPlacement;
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
