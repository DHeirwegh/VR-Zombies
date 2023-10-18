using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>()) //change to layer
            GetComponent<Weapon>().DoDamage(other.GetComponent<Health>());
    }
}