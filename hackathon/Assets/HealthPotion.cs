using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Collectables
{

    void Start() {
      pointValue = 10;
      objName = "Health Potion";
    }


    void onTriggerEnter2D(Collider other) {
      Notify(this, NotificationType.healthPotion);
      Destroy(gameObject);
    }
}
