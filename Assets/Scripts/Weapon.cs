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

    private Coroutine _FireCoroutine = null;
    private Coroutine _ReloadingCoroutine = null;

    public void DoDamage(Health otherHealth)
    {
        if (_FireCoroutine == null && _ReloadingCoroutine == null)
            _FireCoroutine = StartCoroutine(IE_DoDamage(otherHealth));
    }

    private IEnumerator IE_DoDamage(Health otherHealth)
    {
        otherHealth.DoDamage(_Damage);
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