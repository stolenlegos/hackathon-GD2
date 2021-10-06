using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Collectables
{

    void Start() {
      pointValue = 10;
      objName = "Health Potion";
    }


    void OnTriggerEnter2D(Collider2D other) {
      if (other.tag == "Player") {
        Notify (this, NotificationType.healthPotion);
        Destroy(gameObject);
      }
    }
}
