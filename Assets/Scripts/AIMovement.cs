using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private Transform _Target;
    private float _TargetUpdateTime = .5f;
    private NavMeshAgent _NavMeshAgent;

    //target to move to
    private void Start()
    {
        _Target = FindObjectOfType<PlayerMovement>().transform;
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        if (_NavMeshAgent)
            StartCoroutine(IE_MoveToTarget());
    }

    //coroutine to change the target
    //
    private IEnumerator IE_MoveToTarget()
    {
        while (true)
        {
            _NavMeshAgent.SetDestination(_Target.position);
            yield return new WaitForSeconds(.5f);
        }
    }
}