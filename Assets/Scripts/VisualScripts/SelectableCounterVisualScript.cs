using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableCounterVisualScript : MonoBehaviour
{
    
    [SerializeField] private GameObject[] visualGameObjectArray;
    [SerializeField] private ParentClass_Counter counterObject;
    [SerializeField] private PlayerInteractObjects playerInteractObjects;

    private void Start(){
      playerInteractObjects.OnClosestCounterChange += PlayerInteractObjects_OnClosestCounterChange; //Subscribe to the event in the PlayerInteractObjects
    }

    private void PlayerInteractObjects_OnClosestCounterChange(object sender, PlayerInteractObjects.OnClosestCounterChangeEventArgs e){
      if(e.closestCounterRef == counterObject){
        Show();
      }
      else{
        Hide();
      }
    }

    private void Show(){
      foreach (GameObject visualGameObject in visualGameObjectArray){
        visualGameObject.SetActive(true);
      }
    }

    private void Hide(){
      foreach (GameObject visualGameObject in visualGameObjectArray){
        visualGameObject.SetActive(false);
      }
    }
}
