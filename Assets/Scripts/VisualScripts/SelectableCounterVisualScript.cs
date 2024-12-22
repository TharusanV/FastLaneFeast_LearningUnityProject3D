using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableCounterVisualScript : MonoBehaviour
{
    
    [SerializeField] private GameObject visualGameObject;
    [SerializeField] private BaseCounter baseCounterObject;
    [SerializeField] private PlayerInteractObjects playerInteractObjects;

    private void Start(){
      playerInteractObjects.OnClosestCounterChange += PlayerInteractObjects_OnClosestCounterChange; //Subscribe to the event in the PlayerInteractObjects
    }

    private void PlayerInteractObjects_OnClosestCounterChange(object sender, PlayerInteractObjects.OnClosestCounterChangeEventArgs e){
      if(e.closestCounterRef == baseCounterObject){
        Show();
      }
      else{
        Hide();
      }
    }

    private void Show(){
      visualGameObject.SetActive(true);
    }

    private void Hide(){
      visualGameObject.SetActive(false);
    }
}
