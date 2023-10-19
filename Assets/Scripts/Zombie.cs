using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using Unity.AI.Navigation;

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

    private IEnumerator IE_DoDamage(Health h)
    {
        h.DoDamage(_Damage);
        yield return new WaitForSeconds(_Cooldown);
        _DamageCoroutine = null;
    }
}