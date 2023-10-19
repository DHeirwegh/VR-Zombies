using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private const int _MaxBullets = 10;

    [SerializeField] private GameObject _BulletPrefab = null;
    private int _Ctr = 0;

    private GameObject[] _Bullets = new GameObject[_MaxBullets];

    private void Start()
    {
        for (int i = 0; i < _MaxBullets; i++)
        {
            _Bullets[i] = Instantiate(_BulletPrefab);
            _Bullets[i].SetActive(false);
        }
    }
}