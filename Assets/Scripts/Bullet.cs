using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _Damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            collision.gameObject.GetComponent<Health>()?.DoDamage(_Damage);
        gameObject.SetActive(false);
    }
}