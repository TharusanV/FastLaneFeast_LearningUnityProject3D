using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisualScript : MonoBehaviour
{
    
    [SerializeField] private GameObject visualGameObject;

    private void Show(){
      visualGameObject.SetActive(true);
    }

    private void Hide(){
      visualGameObject.SetActive(true);
    }
}
