using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public Transform Target;

    NavMeshAgent _navmesh;

    private void Start()
    {
        Target = GameObject.Find("Player").transform;
        _navmesh = GetComponent<NavMeshAgent>();
        _navmesh.stoppingDistance=.8f;
    }

    private void Update()
    {
        _navmesh.SetDestination(Target.position);
    }
}
