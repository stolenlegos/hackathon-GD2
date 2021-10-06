using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Collectables
{
    // Start is called before the first frame update
    void Start()
    {
      pointValue = 20;
      objName = "Speed Boost";
    }

    void OnTriggerEnter2D (Collider2D other) {
      if (other.tag == "Player") {
        Notify(this, NotificationType.lightning);
        Destroy(gameObject);
      }
    }
}
