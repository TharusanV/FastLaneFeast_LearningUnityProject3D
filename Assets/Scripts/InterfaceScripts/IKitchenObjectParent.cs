using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    // Interface contains only method declarations with the body of the interface method is provided by the "implement" class

    //By forcing all that use this interface to include these methods, we can make it so every single one that uses this interface will be able to hold these the kitchen object

    //We did not use inheritance as the things that can hold objects e.g. kitchen objects, player and counters, are two very different things so it doesn't make sense
    //Use inheritance for only very similar and related objects

    public Transform GetItemPlacementTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();

}
