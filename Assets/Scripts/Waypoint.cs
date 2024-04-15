using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  [SerializeField] Tower tower;
  [SerializeField] bool isPlacebled = false;
  public bool IsPlacebled{ get {return isPlacebled;}}
  void OnMouseDown(){
    if(isPlacebled) {
      bool isPlaced = tower.CreatTower(tower, transform.position);
      isPlacebled = !isPlaced;
    }
  }
}
