using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Health>().OnDeath += Player_OnDeath;
    }

    private void Player_OnDeath()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}