using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _Frequency = 1;
    [SerializeField] private int _Damage = 1;
    [SerializeField] private int _MaxBullets = -1; //-1 = infinite
    [SerializeField] private int _CurrBullets = 0;
    [SerializeField] private float _ReloadTime = 1f;
    [SerializeField] private GameObject _bulletGO;
    [SerializeField] private Transform _bulletSocket;

    private Coroutine _FireCoroutine = null;
    private Coroutine _ReloadingCoroutine = null;

    private void FireBullet()
    {
        if (_FireCoroutine == null && _ReloadingCoroutine == null)
            _FireCoroutine = StartCoroutine(IE_FireBullet());
    }

    private IEnumerator IE_FireBullet()
    {
        Instantiate(_bulletGO);
        yield return new WaitForSeconds(1f / _Frequency);
        _FireCoroutine = null;

        if (_CurrBullets == 0)
            _ReloadingCoroutine = StartCoroutine(IE_StartReloading());
    }

    private IEnumerator IE_StartReloading()
    {
        yield return new WaitForSeconds(_ReloadTime);
        _ReloadingCoroutine = null;
    }
}