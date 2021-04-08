using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1AI : MonoBehaviour
{

    public Transform target;
    public NavMeshAgent move;

    // Start is called before the first frame update
    void Start()
    {
        target = FindPlayer.found.player.transform;
        move = GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        move.SetDestination(target.position);
        transform.LookAt(target);
    }
}
