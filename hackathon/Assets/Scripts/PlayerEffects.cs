using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour, Observer
{
  private int health;

  void Start() {
    health = 100;
  }


  public void OnNotify (Object obj, NotificationType noTy) {
    if (noTy == NotificationType.healthPotion && health < 100) {
      health += 10;
    } else if (noTy == NotificationType.powerUp) {
      //do powerup
    }
  }
}
