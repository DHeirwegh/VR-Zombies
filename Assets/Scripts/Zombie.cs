using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using Unity.AI.Navigation;
using System;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int _Damage = 1;
    [SerializeField] private float _Cooldown = 1f;

    private Coroutine _DamageCoroutine = null;

    private void OnTriggerEnter(Collider other)
    {
        if (_DamageCoroutine == null && other.GetComponent<PlayerMovement>())
        {
            var health = other.GetComponent<Health>();
            if (health) _DamageCoroutine = StartCoroutine(IE_DoDamage(health));
        }
    }

    private void Start()
    {
        GetComponent<Health>().OnDeath += Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void ResetZombie()
    {
        GetComponent<Health>()?.ResetHealth();
    }

    private IEnumerator IE_DoDamage(Health h)
    {
        h.DoDamage(_Damage);
        yield return new WaitForSeconds(_Cooldown);
        _DamageCoroutine = null;
    }
}