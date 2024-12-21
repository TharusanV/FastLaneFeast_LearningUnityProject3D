using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounterScript : MonoBehaviour
{

    public void Interact(ClearCounterScript counter){
        if(gameObject.name == counter.gameObject.name){
            Debug.Log("Pressed 'E' and has successfully interacted!");
        }
    }
}
