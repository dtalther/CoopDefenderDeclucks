using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public NavMeshAgent move;
    public float speed;
    public bool canMove;
    public Gun weapon;
    void Start()
    {
        target = GameObject.Find("ChickenAllyPathStart").transform;
        move = GetComponent<NavMeshAgent>();
        move.speed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && canMove)
        {
            move.SetDestination(target.position);
        }
    }
}
