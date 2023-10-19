using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ZombiePrefab;
    private int _MaxZombies;

    private Transform _PlayerPos;

    private List<GameObject> _Zombies = new List<GameObject>();

    private void Start()
    {
        _PlayerPos = FindObjectOfType<Player>().transform;

        for (int i = 0; i < _MaxZombies; i++)
        {
            _Zombies[i] = Instantiate(_ZombiePrefab);
            _Zombies[i].GetComponent<Health>().OnDeath += OnZombieDeath;
            _Zombies[i].SetActive(false);
        }
    }

    private void OnZombieDeath()
    {
        for (int i = 0; i < _Zombies.Count; i++)
        {
            if (_Zombies[i].activeSelf) continue;

            _Zombies[i].GetComponent<Zombie>().ResetZombie();
            SpawnZombie(i);
        }
    }

    private void SpawnZombie(int zombie)
    {
        var playerpos = _PlayerPos.position;

        Vector2 pos = new Vector2(Random.Range(0, 1000) / 1000f, Random.Range(0, 1000) / 1000f);
        //TODO
        _Zombies[zombie].gameObject.transform.position = ;
    }
}