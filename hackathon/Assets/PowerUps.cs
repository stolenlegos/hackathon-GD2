using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Collectables
{
    // Start is called before the first frame update
    void Start()
    {
      pointValue = 20;
      objName = "Power Up";
    }


    void onTriggerEnter2D(Collider2D other) {
      Notify(this, NotificationType.powerUp);
      Destroy(gameObject);
    }
}
