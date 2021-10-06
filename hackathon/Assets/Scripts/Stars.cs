using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : Collectables
{
    // Start is called before the first frame update
    void Start()
    {
      pointValue = 100;
      objName = "Star";
    }


    void OnTriggerEnter2D(Collider2D other) {
      Notify(this, NotificationType.star);
      Destroy(gameObject);
    }
}
