using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScripts : MonoBehaviour
{
    public Slider slider;
    public PlayerEffects player;
    private int _maxHealth;
    private int _currentHealth;
    private bool _loseStateReached = false;
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        _maxHealth = health;
        _currentHealth = health;
    }
    public void SetHealth(int health) {
        slider.value = health;
        _currentHealth = health;
    }

    public void AddHealth(int health) {
        slider.value += health;
        _currentHealth += health;
    }

    public void SubHealth(int health) {
        slider.value -= health;
        _currentHealth -= health;
    }

    private void Update() {
        slider.value = player.health;
    }
}
