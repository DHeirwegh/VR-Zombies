using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private const int _MaxBullets = 10;

    [SerializeField] private GameObject _BulletPrefab = null;
    private int _Ctr = 0;
    private float _BulletSpeed = 10;

    private GameObject[] _Bullets = new GameObject[_MaxBullets];

    private void Start()
    {
        for (int i = 0; i < _MaxBullets; i++)
        {
            _Bullets[i] = Instantiate(_BulletPrefab);
            _Bullets[i].SetActive(false);
        }
    }

    public void FireBullet(Vector3 start, Vector3 dir)
    {
        var curr = _Bullets[_Ctr];
        curr.SetActive(true);
        curr.transform.position = start;
        curr.GetComponent<Rigidbody>().velocity = dir.normalized * _BulletSpeed;
        ++_Ctr;
    }
}