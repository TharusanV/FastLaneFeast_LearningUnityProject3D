using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    //We use this script on the parent object that represents a scriptable object in order to create a reference to it as scriptable objects are not monotype

    [SerializeField] private ScriptableObject_KitchenObject kitchenObjectSO;
    private IKitchenObjectParent kitchenObjectParent;

    public ScriptableObject_KitchenObject GetKitchenObjectSO(){
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent newKitchenObjectParent) {
        //We clear the old counter object in the counter script by calling the function in that script
        if(this.kitchenObjectParent != null){
            this.kitchenObjectParent.ClearKitchenObject();
        }

        //Add new counter where the object will be
        this.kitchenObjectParent = newKitchenObjectParent; 
        if(newKitchenObjectParent.HasKitchenObject() ){
            //Safety check to ensure that the counter is not holding something
            Debug.Log("Counter already has object");
        }
        newKitchenObjectParent.SetKitchenObject(this);
        
        //update visual
        transform.parent = newKitchenObjectParent.GetItemPlacementTransform(); //Move the visual
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent(){
        return kitchenObjectParent;
    }




}
