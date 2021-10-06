using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour, Observer
{
    private float _movementSpeed;
    private float _jumpForce;
    private Rigidbody2D _rb;
    private bool speedy;
    private float speedTimer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movementSpeed = 3.0f;
        _jumpForce = 10.0f;
        foreach (SubjectBeingObserved subject in FindObjectsOfType<SubjectBeingObserved>()) {
            subject.AddObserver(this);
        }
        speedy = false;
        speedTimer = 5f;
    }
    private void Update()
    {
        //move the character
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _movementSpeed;

        //flip the character
        Vector2 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001) {
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        if (speedy) {
          speedTimer -= Time.deltaTime;
        } else if (!speedy) {
          speedTimer = 5f;
        }

        if (speedTimer <= 0) {
          speedy = false;
          _movementSpeed = 3f;
        }

        Debug.Log(speedy);
        Debug.Log(_movementSpeed);
    }

    public float getMovementSpeed() {
        return _movementSpeed;
    }

    public void setMovementSpeed(float newSpeed) {
        _movementSpeed = newSpeed;
    }

    public float getJumpForce() {
        return _jumpForce;
    }

    public void setJumpForce(float newForce) {
        _jumpForce = newForce;
    }


    public void OnNotify (Object obj, NotificationType noTy) {
      if (noTy == NotificationType.lightning) {
        speedy = true;
        _movementSpeed *= 1.5f;
        Debug.Log("Notified");
      }
    }
}
