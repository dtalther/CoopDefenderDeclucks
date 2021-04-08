using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1AI : MonoBehaviour
{

    Transform target;
    NavMeshAgent move;

    // Start is called before the first frame update
    void Start()
    {
        target = FindPlayer.found.player.transform;
        move = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        move.SetDestination(target.position);
    }
}
