using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : ParentClass_Counter{

    [SerializeField] private ScriptableObject_KitchenObject kitchenObjectSO;

    public override void Interact(PlayerInteractObjects player){
        //Can be used to place and pickup items
    }



}
