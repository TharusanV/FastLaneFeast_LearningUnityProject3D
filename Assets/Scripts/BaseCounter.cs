using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private ScriptableObject_KitchenObject kitchenObjectSO;
    [SerializeField] private Transform itemPlacement;

    private KitchenObject kitchenObject;

    public void Interact(PlayerInteractObjects player){
        //Debug.Log(counter.name + " Pressed 'E' and has successfully interacted!");

        if(kitchenObject == null){
            Transform kitchenObjectSO_Transform = Instantiate(kitchenObjectSO.prefab, itemPlacement);
            kitchenObjectSO_Transform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else{
            //Something is on the counter and the player will pick it up
            kitchenObject.SetKitchenObjectParent(player);
        }
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
