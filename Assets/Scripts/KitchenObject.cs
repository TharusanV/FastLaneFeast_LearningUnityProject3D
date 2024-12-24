using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    //We use this script on the parent object that represents a scriptable object in order to create a reference to it as scriptable objects are not monotype

    [SerializeField] private KitchenObjectSO prefab;
    private IHoldObjectParent objectHolder;
    public bool canCut;

    public KitchenObjectSO GetKitchenObjectSO(){
        return prefab;
    }

    public void SetKitchenObjectParent(IHoldObjectParent newObjectHolder) {
        //We clear the old counter object in the counter script by calling the function in that script
        if(this.objectHolder != null){
            this.objectHolder.ClearHeldObject();
        }

        //Add new counter where the object will be
        this.objectHolder = newObjectHolder; 
        if(newObjectHolder.IsHoldingObject() ){
            //Safety check to ensure that the counter is not holding something
            Debug.Log("Counter already has object");
        }
        newObjectHolder.SetHeldObject(this);
        
        //update visual
        transform.parent = newObjectHolder.GetItemPlacementTransform(); //Move the visual
        transform.localPosition = Vector3.zero;
    }

    public IHoldObjectParent GetKitchenObjectParent(){
        return objectHolder;
    }

    public void DestroySelf(){
        objectHolder.ClearHeldObject();

        Destroy(gameObject); //Could be a problem if you got bare objects

        //Use this function is other scripts by just doing GetKitchenObject().DestroySelf()
    }

    public static KitchenObject SpawnObject(KitchenObjectSO kitchenObjectSO, IHoldObjectParent objectHolder) {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);

        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        
        kitchenObject.SetKitchenObjectParent(objectHolder);

        return kitchenObject;
    }




}
