using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : ParentClass_Counter
{
    [SerializeField] private ScriptableObject_KitchenObject kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(PlayerInteractObjects player){
        //Can be used to pick up and place items. As well as spawn items

        Transform kitchenObjectSO_Transform = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectSO_Transform.GetComponent<KitchenObject>().SetKitchenObjectParent(player); //Straight to player
        
         OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);

    }
}
