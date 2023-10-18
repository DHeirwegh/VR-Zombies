using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _Health = 3;
    private int _MaxHealth;

    public event Action OnDeath = delegate { };

    //public evenet Action<float> OnDeath; to add a float to the function

    private void Awake()
    {
        _MaxHealth = _Health;
    }

    public void DoDamage(int damage = 1)
    {
        _Health -= damage;

        if (_Health <= 0)
            OnDeath.Invoke();
    }

    public void ResetHealth()
    {
        _Health = _MaxHealth;
    }

    public void SetMaxHealth()
    {
        _Health = _MaxHealth;
    }
}