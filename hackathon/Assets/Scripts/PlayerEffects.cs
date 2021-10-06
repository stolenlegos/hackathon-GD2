using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour, Observer
{
  private int health;
  public bool noDam;
  private float timer;

  void Start() {
    health = 100;
    noDam = false;
    timer = 5f;

    foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
        subject.AddObserver(this);
    }
  }


  void Update() {
    if (noDam) {
      timer -= Time.deltaTime;
    } else if (!noDam) {
      timer = 5f;
    }

    if (timer < 0) {
      noDam = false;
    }

    Debug.Log(health);
    Debug.Log(noDam);
    Debug.Log(timer);
  }


  public void OnNotify (Object obj, NotificationType noTy) {
    Debug.Log("Recieved");
    if (noTy == NotificationType.healthPotion) {
      health += 10;
    } else if (noTy == NotificationType.star) {
      noDam = true;
    }
  }
}
